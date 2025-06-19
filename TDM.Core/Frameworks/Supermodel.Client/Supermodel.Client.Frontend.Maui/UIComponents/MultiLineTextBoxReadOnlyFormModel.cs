using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class MultiLineTextBoxReadOnlyFormModel : SingleCellReadOnlyUIComponentForTextFormModel
{
    #region Constructors
    public MultiLineTextBoxReadOnlyFormModel()
    {
        TextLabel = new Label
        {
            FontSize = FormsSettings.LabelFontSize,
            TextColor = FormsSettings.ValueTextColor,
            HorizontalTextAlignment = TextAlignmentIfApplies,
        };
        TextLabel.SetBinding(Entry.TextProperty, "Text");

        SetGridColumns(1);
        Grid.ColumnDefinitions[0] = new ColumnDefinition(GridLength.Star);

        Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

        Grid.Add(TextLabel, 0, 1);
    }
    #endregion

    #region Properties
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
    public Label TextLabel { get; }
    public sealed override TextAlignment TextAlignmentIfApplies { get; set; } = TextAlignment.Start;
    #endregion
}