using Android.Widget;
using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class TextBoxMauiModel : ViewCell
{
    #region Constrcutors

    public TextBoxMauiModel()
    {
        View = new Grid()
        {
            ColumnDefinitions = { new ColumnDefinition(GridLength.Auto), new ColumnDefinition(GridLength.Star) }
        };
    }

    #endregion

    #region Properties

    public Grid ViewAsGrid => (Grid)View;

    #endregion
}

public class TextBoxReadOnlyXFModel : SingleCellReadOnlyUIComponentForTextMauiModel
{
    #region Constructors
    public TextBoxReadOnlyMauiModel()
    {
        TextLabel = new Label { HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Center, LineBreakMode = LineBreakMode.TailTruncation, FontSize = MauiSettings.LabelFontSize, TextColor = MauiSettings.ValueTextColor };
        StackLayoutView.Children.Add(TextLabel);
    }
    #endregion

    #region ICustomMapper implemtation
    public override Task<T> MapToCustomAsync<T>(T other)
    {
        return Task.FromResult(other);
    }
    #endregion

    #region Properties
    public override string Text
    {
        get => TextLabel.Text;
        set => TextLabel.Text = value;
    }
    public Label TextLabel { get; }
    public override TextAlignment TextAlignmentIfApplies
    {
        get => TextLabel.HorizontalTextAlignment;
        set => TextLabel.HorizontalTextAlignment = value;
    }
    #endregion
}