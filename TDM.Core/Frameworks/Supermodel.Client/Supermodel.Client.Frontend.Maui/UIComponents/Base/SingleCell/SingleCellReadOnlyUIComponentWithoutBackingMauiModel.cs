namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public abstract class SingleCellReadOnlyUIComponentWithoutBackingMauiModel : ViewCell, IReadOnlyUIComponentMauiModel
{
    #region Constructors
    protected SingleCellReadOnlyUIComponentWithoutBackingMauiModel()
    {
        View = new StackLayout
        {
            Padding = new Thickness(8, 0, 8, 0), 
            Orientation = StackOrientation.Horizontal, 
            VerticalOptions = LayoutOptions.CenterAndExpand, 
            HorizontalOptions = LayoutOptions.FillAndExpand,
            HeightRequest = 40,
        };

        DisplayNameLabel = new Label { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, TextColor = XFormsSettings.LabelTextColor, LineBreakMode = LineBreakMode.NoWrap, FontSize = XFormsSettings.LabelFontSize };

        LabelView = new StackLayout
        {
            Padding = new Thickness(0, 0, 0, 0),
            Orientation = StackOrientation.Horizontal,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.Start,
            HeightRequest = 40,
            Children = { DisplayNameLabel }
        };

        if (ShowDisplayNameIfApplies) StackLayoutView.Children.Add(LabelView);
    }
    #endregion

    #region ISupermodelMobileDetailTemplate implemetation
    public List<Cell> RenderDetail(Page parentPage, int screenOrderFrom = int.MinValue, int screenOrderTo = int.MaxValue)
    {
        ParentPage = parentPage;
        return new List<Cell> { this };
    }
    #endregion

    #region Properties
    public StackLayout StackLayoutView
    {
        get => (StackLayout)View;
        set => View = value;
    }
    public StackLayout LabelView { get; set; }

    public bool ShowDisplayNameIfApplies
    {
        get => _showDisplayNameIfApplies;
        set
        {
            if (_showDisplayNameIfApplies == value) return;
            if (value) StackLayoutView.Children.Insert(0, DisplayNameLabel);
            else StackLayoutView.Children.RemoveAt(StackLayoutView.Children.IndexOf(DisplayNameLabel));
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

    public Page ParentPage { get; set; }

    public abstract TextAlignment TextAlignmentIfApplies { get; set; }
    #endregion    
}