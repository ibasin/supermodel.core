namespace Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

public abstract class SingleCellReadOnlyUIComponentWithoutBackingMauiModel : ViewCell, IReadOnlyUIComponentMauiModel
{
    #region Constructors
    protected SingleCellReadOnlyUIComponentWithoutBackingMauiModel()
    {

        DisplayNameLabel = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, TextColor = MauiSettings.LabelTextColor, LineBreakMode = LineBreakMode.NoWrap, FontSize = MauiSettings.LabelFontSize };
        Grid = new Grid
        {
            RowDefinitions = [new RowDefinition(new GridLength(40))]
        };
        if (ShowDisplayNameIfApplies)
        {
            Grid.ColumnDefinitions = [new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star)];
            Grid.Add(DisplayNameLabel);
        }
        else
        {
            Grid.ColumnDefinitions = [new ColumnDefinition(GridLength.Star)];
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

    #region Properties
    public Grid Grid
    {
        get => (Grid)View;
        set => View = value;
    }

    public bool ShowDisplayNameIfApplies
    {
        get => _showDisplayNameIfApplies;
        set
        {
            if (_showDisplayNameIfApplies == value) return;
            if (value)
            {
                Grid.ColumnDefinitions = [new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star)];
                Grid.Add(DisplayNameLabel);
            }
            else
            {
                Grid.ColumnDefinitions = [new ColumnDefinition(GridLength.Star)];
                Grid.RemoveAt(Grid.IndexOf(DisplayNameLabel));
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