namespace Supermodel.Client.Frontend.Maui.UIComponents.CustomCells;

public class AddNewCell : ViewCell
{
    #region Constructors
    public AddNewCell(string? imageFileName)
    {
        Grid = new Grid
        {
            RowDefinitions = [new RowDefinition(new GridLength(40))],
            ColumnSpacing = 5,
            HorizontalOptions = LayoutOptions.Fill,
            Padding = new Thickness(5, 0),
        };

        
        if (!string.IsNullOrEmpty(imageFileName))
        {
            SetGridColumns(2);
            AddNewImage = new Image { Source = imageFileName };
            Grid.Add(AddNewImage, 1);
        }
        else
        {
            SetGridColumns(1);
        }
        SetGridRows(2);

        AddNewLabel = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, Text = "Add New", FontSize = FormsSettings.LabelFontSize };
        Grid.Add(AddNewLabel, 0);
    }
    #endregion

    #region Helper Methods
    protected void SetGridColumns(int count)
    {
        Grid.ColumnDefinitions.Clear();
        Grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        for (var i = 1; i < count; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        }
    }
    protected void SetGridRows(int count)
    {
        Grid.RowDefinitions.Clear();
        //Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        for (var i = 0; i < count; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        }
    }
    #endregion

    #region Properties
    public Page? ParentPage { get; set; }

    public Grid Grid
    {
        get => (Grid)View;
        set => View = value;
    }

    public string Text
    {
        get => AddNewLabel.Text;
        set => AddNewLabel.Text = value;
    }

    public Label AddNewLabel { get; }
    public Image? AddNewImage { get; }

    public bool Required
    {
        get => _required;
        set
        {
            AddNewLabel.TextColor = value ? FormsSettings.RequiredLabelTextColor : FormsSettings.LabelTextColor;
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
    #endregion
}