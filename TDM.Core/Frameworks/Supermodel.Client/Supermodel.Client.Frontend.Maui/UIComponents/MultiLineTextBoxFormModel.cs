using Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;
using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class MultiLineTextBoxFormModel : SingleCellWritableUIComponentForTextFormModel
{
    #region Constructors
    public MultiLineTextBoxFormModel(Keyboard keyboard) : this()
    {
        Editor.Keyboard = keyboard;
    }
    public MultiLineTextBoxFormModel()
    {
        Editor = new Editor
        {
            HorizontalOptions = LayoutOptions.End,
            HeightRequest = FormsSettings.MultiLineTextBoxCellHeight - FormsSettings.MultiLineTextLabelHeight,
            FontSize = FormsSettings.ValueFontSize,
            TextColor = FormsSettings.ValueTextColor,
            HorizontalTextAlignment = TextAlignmentIfApplies,
        };
        Editor.SetBinding(Entry.TextProperty, "Text");
        Editor.PropertyChanged += (_, _) =>
        {
            if (_currentValue != Editor.Text)
            {
                _currentValue = Editor.Text;
                OnChanged?.Invoke((IBasicCRUDDetailPage)ParentPage!);
            }
        };
        Tapped += (_, _) => Editor.Focus();

        SetHeight(FormsSettings.MultiLineTextBoxCellHeight);

        SetGridColumns(1);
        Grid.ColumnDefinitions[0] = new ColumnDefinition(GridLength.Star);

        Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));

        Grid.Add(Editor, 0, 1);
    }
    #endregion

    #region EventHandling
    public Action<IBasicCRUDDetailPage>? OnChanged { get; set; }
    #endregion

    #region Properties
    public void SetHeight(int newHeight)
    {
        Height = newHeight;
        Editor.HeightRequest = ShowDisplayNameIfApplies ? newHeight - FormsSettings.MultiLineTextLabelHeight : newHeight - 20;
    }
    public override string Text
    {
        get => Editor.Text;
        set
        {
            _currentValue = value;
            if (value == Editor.Text) return;
            Editor.Text = value;
            OnPropertyChanged();
        }
    }
    private string _currentValue = "";

    public Editor Editor { get; }
    public sealed override TextAlignment TextAlignmentIfApplies { get; set; } = TextAlignment.Start; 

    public bool Active
    {
        get => _active;
        set
        {
            if (_active == value) return;
            _active = IsEnabled = value;
            DisplayNameLabel.TextColor = value ? FormsSettings.LabelTextColor : FormsSettings.DisabledTextColor;
            Editor.TextColor = value ? FormsSettings.ValueTextColor : FormsSettings.DisabledTextColor;
        }
    }
    private bool _active = true;
    #endregion
}