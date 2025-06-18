using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Supermodel.Client.Frontend.Maui.UIComponents;
using Supermodel.Client.Frontend.Maui.UIComponents.Base;
using Supermodel.DataAnnotations.Attributes;
using Supermodel.DataAnnotations.Validations;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.ViewModels;

public abstract class ViewModelForMaui : ISupermodelMobileDetailTemplate, IAsyncValidatableObject 
{
    #region ISupermodelMobileDetailTemplate
    public virtual List<Cell> RenderDetail(Page parentPage, int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue)
    {
        var cells = new List<Cell>();
        foreach (var property in GetPropertiesInOrder(screenOrderFrom, screenOrderTo))
        {
            var propertyObj = this.PropertyGet(property.Name);
            if (typeof(ISupermodelMobileDetailTemplate).IsAssignableFrom(property.PropertyType))
            {
                //We use existing object if it exists, otherwise we just create a blank object for our purposes
                if (propertyObj == null)
                {
                    if (property.PropertyType.GetConstructor(Type.EmptyTypes) == null) throw new Exception($"Property '{property.Name}' is null and no default constructor exists for the type '{property.PropertyType.Name}'");
                    propertyObj = ReflectionHelper.CreateType(property.PropertyType);
                }

                //Set up display name and Required
                if (propertyObj is IReadOnlyUIComponentMauiModel uiReadOnlyComponent)
                {
                    //Set up display name if not already set
                    if (string.IsNullOrEmpty(uiReadOnlyComponent.DisplayNameIfApplies)) uiReadOnlyComponent.DisplayNameIfApplies = GetType().GetDisplayNameForProperty(property.Name);

                    //Set required asterisk
                    var requiredAttribute = property.GetCustomAttributes(typeof(RequiredAttribute), true).SingleOrDefault() != null;
                    var noRequiredLabelAttribute = property.GetCustomAttributes(typeof(NoRequiredLabelAttribute), true).SingleOrDefault() != null;
                    var forceRequiredLabelAttribute = property.GetCustomAttributes(typeof(ForceRequiredLabelAttribute), true).SingleOrDefault() != null;

                    if (uiReadOnlyComponent is IWritableUIComponentMauiModel uiComponent)
                    {
                        uiComponent.Required = (requiredAttribute || forceRequiredLabelAttribute) && ! noRequiredLabelAttribute;
                    }
                }

                // ReSharper disable once PossibleNullReferenceException
                cells.AddRange(((ISupermodelMobileDetailTemplate)propertyObj).RenderDetail(parentPage));
            }
            else
            {
                if (propertyObj == null) throw new SystemException("propertyObj == null");
                var genericCell = new TextBoxReadOnlyMauiModel
                {
                    DisplayNameIfApplies = GetType().GetDisplayNameForProperty(property.Name),
                    Text = propertyObj.ToString() ?? ""
                };
                cells.Add(genericCell);
            }
        }
        return cells;
    }
    #endregion

    #region Methods
    public virtual bool AreWritableFieldsEqual(ViewModelForMaui viewModelForMaui)
    {
        foreach (var property in GetPropertiesInOrder())
        {
            if (this.PropertyGet(property.Name) is IWritableUIComponentMauiModel uiComponent)
            {
                var mine = uiComponent.WrappedValue;
                // ReSharper disable once SuspiciousTypeConversion.Global
                var theirs = ((IWritableUIComponentMauiModel)viewModelForMaui.PropertyGet(property.Name)!).WrappedValue;
                if (mine != null)
                {
                    if (!mine.Equals(theirs)) return false;
                }
                else
                {
                    if (theirs != null) return false;
                }
            }
        }
        return true;
    }
    public virtual void ClearValidationErrors()
    {
        foreach (var property in GetPropertiesInOrder())
        {
            if (this.PropertyGet(property.Name) is IWritableUIComponentMauiModel uiComponent) uiComponent.ErrorMessage = null;
        }
    }
    public virtual void ShowValidationErrors(IEnumerable<ValidationResult>? vr)
    {
        if (vr == null) vr = new ValidationResultList();
        foreach (var property in GetPropertiesInOrder())
        {
            // ReSharper disable PossibleMultipleEnumeration
            if (this.PropertyGet(property.Name) is IWritableUIComponentMauiModel uiComponent)
            {
                uiComponent.ErrorMessage = null;
                var errors = vr.Where(x => x.MemberNames.Any(y => y == property.Name)).ToList();
                    
                var first = true;
                foreach (var error in errors)
                {
                    if (first)
                    {
                        first = false;
                        uiComponent.ErrorMessage = error.ErrorMessage;
                    }
                    else
                    {
                        uiComponent.ErrorMessage += Environment.NewLine + error.ErrorMessage;
                    }
                }
            }
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
    public virtual bool ContainsValidationErrors()
    {
        foreach (var property in GetPropertiesInOrder())
        {
            var uiComponent = this.PropertyGet(property.Name) as IWritableUIComponentMauiModel;
            if (uiComponent?.ErrorMessage != null) return true;
        }
        return false;
    }
    #endregion

    #region Validation
    public virtual Task<ValidationResultList> ValidateAsync(ValidationContext validationContext)
    {
        var vr = new ValidationResultList();
        foreach (var property in GetPropertiesInOrder())
        {
            var propertyObj = this.PropertyGet(property.Name);

            //Check all required UIComponents
            if (propertyObj is IWritableUIComponentMauiModel uiComponent && property.GetCustomAttributes(typeof(RequiredAttribute), true).SingleOrDefault() != null)
            {
                var preparedError = new ValidationResult("The " + GetType().GetDisplayNameForProperty(property.Name) + " field is required", new [] { property.Name });

                var value = uiComponent.WrappedValue;
                if (value == null)
                {
                    vr.Add(preparedError);    
                }
                else
                {
                    if (value is string strValue && string.IsNullOrWhiteSpace(strValue)) vr.Add(preparedError);    
                }
            }
        }
        return Task.FromResult(vr);
    }
    #endregion

    #region Private Helpers
    protected virtual IEnumerable<PropertyInfo> GetPropertiesInOrder(int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue)
    {
        return GetType().GetProperties()
            .Where(x => x.GetCustomAttribute<ScaffoldColumnAttribute>() == null || x.GetCustomAttribute<ScaffoldColumnAttribute>()!.Scaffold)
            .Where(x => (x.GetCustomAttribute<ScreenOrderAttribute>() != null ? x.GetCustomAttribute<ScreenOrderAttribute>()!.Order : 100) >= screenOrderFrom)
            .Where(x => (x.GetCustomAttribute<ScreenOrderAttribute>() != null ? x.GetCustomAttribute<ScreenOrderAttribute>()!.Order : 100) <= screenOrderTo)
            .OrderBy(x => x.GetCustomAttribute<ScreenOrderAttribute>() != null ? x.GetCustomAttribute<ScreenOrderAttribute>()!.Order : 100);
    }
    #endregion
}