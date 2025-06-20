namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellWritableUIComponentWithoutBackingFormModel : SingleCellReadOnlyUIComponentWithoutBackingFormModel, IWritableUIComponentFormModel
{
    #region Constructors
    protected SingleCellWritableUIComponentWithoutBackingFormModel()
    {
        SetGridRows(2);
    }
    #endregion

    #region Properties
    public bool Required
    {
        get => _required;
        set
        {
            var label = (Label)Grid[0];
            label.TextColor = value ? FormsSettings.RequiredLabelTextColor : FormsSettings.LabelTextColor;

            _required = value;
        }
    }
    private bool _required;
        
    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage == value) return;

            if (!string.IsNullOrEmpty(value))
            {
                var validationLabel = new Label
                {
                    Text = value,
                    FontSize = FormsSettings.ValidationErrorFontSize,
                    TextColor = FormsSettings.ValidationErrorColor,
                };
                Grid.Add(validationLabel, 1, 1);
            }
            else
            {
                Grid.RemoveAt(3);
            }
            _errorMessage = value;
        }
    }
    private string? _errorMessage;

    public abstract object WrappedValue { get; }
    #endregion    
}