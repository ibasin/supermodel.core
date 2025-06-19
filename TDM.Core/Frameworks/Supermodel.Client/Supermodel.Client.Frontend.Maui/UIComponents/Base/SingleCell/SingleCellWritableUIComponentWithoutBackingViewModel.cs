namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellWritableUIComponentWithoutBackingFormModel : SingleCellReadOnlyUIComponentWithoutBackingFormModel, IWritableUIComponentFormModel
{
    #region Constructors
    protected SingleCellWritableUIComponentWithoutBackingFormModel()
    {
        ValidationErrorIndicator = new Button{ Text = "!", TextColor = Colors.Red };
        ValidationErrorIndicator.Clicked += ValidationIndicatorClicked!;
    }
    #endregion

    #region Event Handlers
    // ReSharper disable once AsyncVoidMethod
    public async void ValidationIndicatorClicked(object sender, EventArgs args)
    {
        if (ParentPage != null) await ParentPage.DisplayAlert("", ErrorMessage, "Ok");
    }
    #endregion

    #region Properties
    public Button ValidationErrorIndicator { get; set; }
    public bool Required
    {
        get => _required;
        set
        {
            var label = (Label)Grid[0];
            if (value) label.TextColor = FormsSettings.RequiredLabelTextColor;
            else label.TextColor = FormsSettings.LabelTextColor;

            _required = value;
        }
    }
    private bool _required;
        
    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage == null & value != null)
            {
                Grid.Add(ValidationErrorIndicator);
                SetGridColumns(Grid.ColumnDefinitions.Count + 1);
            }
            if (_errorMessage != null & value == null)
            {
                //this throws NullReferenceException on Android, ignore it
                //try { StackLayoutView.Children.Remove(ValidationErrorIndicator); } catch (NullReferenceException) { }

                Grid.RemoveAt(Grid.ColumnDefinitions.Count - 1);
                SetGridColumns(Grid.ColumnDefinitions.Count - 1);
            }
            _errorMessage = value;
        }
    }
    private string? _errorMessage;

    public abstract object WrappedValue { get; }
    #endregion    
}