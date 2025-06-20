namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellReadOnlyUIComponentForTextFormModel : SingleCellReadOnlyUIComponentFormModel, IHaveTextProperty
{
    #region ICustomMapper implemtation
    public override Task MapFromCustomAsync<T>(T other)
    {
        return SingleCellUIComponentForTextFormModelCommonLibrary.MapFromCustomAsync(this, other);
    }

    public override Task<T> MapToCustomAsync<T>(T other)
    {
        return SingleCellUIComponentForTextFormModelCommonLibrary.MapToCustomAsync(this, other);
    }
    #endregion
        
    #region Properties
    public abstract string Text { get; set; }
    #endregion
}