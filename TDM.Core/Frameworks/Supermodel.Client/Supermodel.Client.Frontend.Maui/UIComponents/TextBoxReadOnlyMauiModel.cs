using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;
using Supermodel.DataAnnotations.Exceptions;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class TextBoxReadOnlyMauiModel : SingleCellReadOnlyUIComponentForTextMauiModel
{
    #region Constructors
    public TextBoxReadOnlyMauiModel()
    {
        TextLabel = new Label { VerticalOptions = LayoutOptions.Center, LineBreakMode = LineBreakMode.TailTruncation, FontSize = MauiSettings.LabelFontSize, TextColor = MauiSettings.ValueTextColor };
        switch (Grid.ColumnDefinitions.Count)
        {
            case 1: 
                Grid[0] = TextLabel;
                break;
            case 2:
                Grid[1] = TextLabel;
                break;
            default:
                throw new SupermodelException("TextBoxReadOnlyMauiModel: Grid.ColumnDefinitions.Count not 1 or 2");
        }
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