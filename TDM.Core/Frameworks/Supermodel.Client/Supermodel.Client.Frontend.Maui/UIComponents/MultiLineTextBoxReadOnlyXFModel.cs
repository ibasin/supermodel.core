//using Supermodel.Client.Frontend.Maui.Services;
//using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

//namespace Supermodel.Client.Frontend.Maui.UIComponents;

//public class MultiLineTextBoxReadOnlyXFModel : SingleCellReadOnlyUIComponentForTextViewModel
//{
//    #region Constructors
//    public MultiLineTextBoxReadOnlyXFModel()
//    {
//        TextLabel = new Label
//        {
//            FontSize = MauiSettings.LabelFontSize,
//            TextColor = MauiSettings.ValueTextColor,
//            HeightRequest = MauiSettings.MultiLineTextBoxReadOnlyCellHeight - MauiSettings.MultiLineTextLabelHeight
//        };
//        ScrollView = new ScrollView{ Content = TextLabel, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center };
            
//        TextLabel.SetBinding(Entry.TextProperty, "Text");

//        SetGridColumns();
//        StackLayoutView.Orientation = StackOrientation.Vertical;
//        //StackLayoutView.Padding = Pick.ForPlatform(8, new Thickness(8, 10), 8);
//        StackLayoutView.Padding = Pick.ForPlatform(8, new Thickness(8, 10));
//        StackLayoutView.Children.Add(ScrollView);

//        SetHeight(XFormsSettings.MultiLineTextBoxReadOnlyCellHeight);
//        StackLayoutView.HeightRequest = MauiSettings.MultiLineTextBoxReadOnlyCellHeight;
//    }
//    #endregion

//    #region Properties
//    public void SetHeight(int newHeight)
//    {
//        Height = newHeight;
//        ScrollView.HeightRequest = ShowDisplayNameIfApplies ? newHeight - MauiSettings.MultiLineTextLabelHeight : newHeight - 20;
//    }
//    public override string Text
//    {
//        get => TextLabel.Text;
//        set
//        {
//            if (value == TextLabel.Text) return;
//            TextLabel.Text = value;
//            OnPropertyChanged();
//        }
//    }
//    public ScrollView ScrollView { get; }
//    public Label TextLabel { get; }
//    public override TextAlignment TextAlignmentIfApplies { get; set; }
//    #endregion
//}