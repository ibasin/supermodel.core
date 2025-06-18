using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class TextBoxReadOnlyViewModel : SingleCellReadOnlyUIComponentForTextViewModel
{
    #region Constructors
    public TextBoxReadOnlyViewModel()
    {
        TextLabel = new Label { VerticalOptions = LayoutOptions.Center, LineBreakMode = LineBreakMode.TailTruncation, FontSize = MauiSettings.LabelFontSize, TextColor = MauiSettings.ValueTextColor };
        Grid.Add(TextLabel, 1);

        //switch (Grid.ColumnDefinitions.Count)
        //{
        //    case 1: 
        //        if (Grid.Count > 0) Grid[0] = TextLabel;
        //        else Grid.Add(TextLabel);
        //            break;
        //    case 2:
        //        if (Grid.Count > 1) Grid[1] = TextLabel;
        //        else Grid.Add(TextLabel);
        //        break;
        //    default:
        //        throw new SupermodelException("TextBoxReadOnlyViewModel: Grid.ColumnDefinitions.Count not 1 or 2");
        //}
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