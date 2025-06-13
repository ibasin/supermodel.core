namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellWritableUIComponentWithoutBackingMauiModel : SingleCellReadOnlyUIComponentWithoutBackingMauiModel, IWritableUIComponentMauiModel
{
    #region Constructors
    protected SingleCellWritableUIComponentWithoutBackingMauiModel()
    {
        ValidationErrorIndicator = new Button{ Text = "!", TextColor = Colors.Red };
        ValidationErrorIndicator.Clicked += ValidationIndicatorClicked!;

        RequiredFieldIndicator = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, TextColor = MauiSettings.RequiredAsteriskColor, Text = "*" };
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
    public Label RequiredFieldIndicator { get; set; }
    public bool Required
    {
        get => _required;
        set
        {
            if (!_required && value)
            {
                Grid.ColumnDefinitions = [new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star)];
                Grid.InsertLogicalChild(1, DisplayNameLabel);
            }
            if (_required && !value)
            {
                Grid.ColumnDefinitions = [new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star)];
                Grid.RemoveAt(Grid.IndexOf(RequiredFieldIndicator));
            }
            _required = value;
        }
    }
    private bool _required;
        
    public string? ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage == null & value != null) StackLayoutView.Children.Add(ValidationErrorIndicator);
            if (_errorMessage != null & value == null)
            {
                //this throws NullReferenceException on Android, ignore it
                try { StackLayoutView.Children.Remove(ValidationErrorIndicator); } catch (NullReferenceException) { }
            }
            _errorMessage = value;
        }
    }
    private string? _errorMessage;

    public abstract object WrappedValue { get; }
    #endregion    
}