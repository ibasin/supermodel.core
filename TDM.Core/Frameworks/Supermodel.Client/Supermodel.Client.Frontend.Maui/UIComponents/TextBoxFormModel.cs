using Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;
using Supermodel.Client.Frontend.Maui.UIComponents.Base.SingleCell;
using Supermodel.Client.Frontend.Maui.UIComponents.CustomControls;

namespace Supermodel.Client.Frontend.Maui.UIComponents;

public class TextBoxFormModel : SingleCellWritableUIComponentForTextFormModel
{
    #region Constructors
    public TextBoxFormModel(Keyboard keyboard):this()
    {
        TextEntry.Keyboard = keyboard;
    }
    public TextBoxFormModel()
    {
        TextEntry = new ExtEntry
        {
            HorizontalOptions = LayoutOptions.Fill, 
            VerticalOptions = LayoutOptions.Center, 
            Border = false, 
            HorizontalTextAlignment = TextAlignment.End, 
            FontSize = FormsSettings.LabelFontSize, 
            TextColor = FormsSettings.ValueTextColor
        };
        TextEntry.SetBinding(Entry.TextProperty, "Text");
        TextEntry.PropertyChanged += (_, _) =>
        {
            if (_currentValue != TextEntry.Text)
            {
                _currentValue = TextEntry.Text;
                OnChanged?.Invoke((IBasicCRUDDetailPage)ParentPage!);
            }
        };
        Tapped += (_, _) => TextEntry.Focus();

        Grid.Add(TextEntry, 1);
    }
    #endregion

    #region EventHandling
    public Action<IBasicCRUDDetailPage>? OnChanged { get; set; }
    #endregion

    #region Properties
    public override string Text
    {
        get => TextEntry.Text;
        set
        {
            _currentValue = value;
            if (value == TextEntry.Text) return;
            TextEntry.Text = value;
            OnPropertyChanged();
        }
    }
    private string _currentValue = "";

    public ExtEntry TextEntry { get; }
    public override TextAlignment TextAlignmentIfApplies
    {
        get => TextEntry.TextAlignment;
        set => TextEntry.TextAlignment = value;
    }

    public bool Active
    {
        get => _active;
        set
        {
            if (_active == value) return;
            _active = IsEnabled = value;
            DisplayNameLabel.TextColor = value ? FormsSettings.LabelTextColor : FormsSettings.DisabledTextColor;
            TextEntry.TextColor = value ? FormsSettings.ValueTextColor : FormsSettings.DisabledTextColor;
        }
    }
    private bool _active = true;
    #endregion
}