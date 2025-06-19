using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class MultiLineTextBoxReadOnlyViewModel : SingleCellReadOnlyUIComponentForTextViewModel
{
    #region Constructors
    public MultiLineTextBoxReadOnlyViewModel()
    {
        TextLabel = new Label
        {
            //HorizontalOptions = LayoutOptions.Fill,
            FontSize = MauiSettings.LabelFontSize,
            TextColor = MauiSettings.ValueTextColor,
            HeightRequest = MauiSettings.MultiLineTextBoxReadOnlyCellHeight - MauiSettings.MultiLineTextLabelHeight
        };
        ScrollView = new ScrollView
        {
            Content = TextLabel, 
            //HorizontalOptions = LayoutOptions.Fill, 
            //VerticalOptions = LayoutOptions.FillAndExpand,
            VerticalScrollBarVisibility = ScrollBarVisibility.Always,
            Orientation = ScrollOrientation.Vertical
        };

        TextLabel.SetBinding(Entry.TextProperty, "Text");

        SetGridColumns(1);
        Grid.ColumnDefinitions[0] = new ColumnDefinition(GridLength.Star);
        //SetGridRows(2);
        Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        Grid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
        //Grid.RowDefinitions[1].Height = MauiSettings.MultiLineTextBoxReadOnlyCellHeight;

        Grid.Add(ScrollView, 0, 1);

        //SetHeight(MauiSettings.MultiLineTextBoxReadOnlyCellHeight);
    }
    #endregion

    #region Properties
    public void SetHeight(int newHeight)
    {
        Height = newHeight;
        ScrollView.HeightRequest = ShowDisplayNameIfApplies ? newHeight - MauiSettings.MultiLineTextLabelHeight : newHeight - 20;
    }
    public override string Text
    {
        get => TextLabel.Text;
        set
        {
            if (value == TextLabel.Text) return;
            TextLabel.Text = value;
            OnPropertyChanged();
        }
    }
    public ScrollView ScrollView { get; }
    public Label TextLabel { get; }
    public override TextAlignment TextAlignmentIfApplies { get; set; }
    #endregion
}