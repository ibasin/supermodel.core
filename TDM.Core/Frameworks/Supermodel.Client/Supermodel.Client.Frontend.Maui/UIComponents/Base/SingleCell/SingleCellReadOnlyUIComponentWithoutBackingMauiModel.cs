namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellReadOnlyUIComponentWithoutBackingMauiModel : ViewCell, IReadOnlyUIComponentMauiModel
{
    #region Constructors
    protected SingleCellReadOnlyUIComponentWithoutBackingMauiModel()
    {

        DisplayNameLabel = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, TextColor = MauiSettings.LabelTextColor, LineBreakMode = LineBreakMode.NoWrap, FontSize = MauiSettings.LabelFontSize };
        Grid = new Grid
        {
            RowDefinitions = [new RowDefinition(new GridLength(40))],
            ColumnSpacing = 5
        };
        if (ShowDisplayNameIfApplies)
        {
            Grid.Add(DisplayNameLabel);
            SetGridColumns(2);
        }
        else
        {
            SetGridColumns(1);
        }
    }
    #endregion

    #region ISupermodelMobileDetailTemplate implemetation
    public List<Cell> RenderDetail(Page parentPage, int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue)
    {
        ParentPage = parentPage;
        return [this];
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
    #endregion

    #region Properties
    public Grid Grid
    {
        get => (Grid)View;
        init => View = value;
    }

    public bool ShowDisplayNameIfApplies
    {
        get => _showDisplayNameIfApplies;
        set
        {
            if (_showDisplayNameIfApplies == value) return;
            if (value)
            {
                Grid.Add(DisplayNameLabel);
                SetGridColumns(2);
            }
            else
            {
                Grid.RemoveAt(Grid.IndexOf(DisplayNameLabel));
                SetGridColumns(1);
            }
            _showDisplayNameIfApplies = value;
        }
    }
    private bool _showDisplayNameIfApplies = true;

    public string DisplayNameIfApplies
    {
        get => DisplayNameLabel.Text;
        set => DisplayNameLabel.Text = value;
    }
    public Label DisplayNameLabel { get; set; }

    public Page? ParentPage { get; set; }

    public abstract TextAlignment TextAlignmentIfApplies { get; set; }
    #endregion    
}