using Supermodel.Client.Frontend.Maui.UIComponents.CustomControls;

namespace Supermodel.Client.Frontend.Maui.UIComponents.CustomCells;

public class ImageCellWithEditableText : ViewCell
{
    #region Contructors
    public ImageCellWithEditableText()
    {
        Grid = new Grid
        {
            RowDefinitions = [new RowDefinition(new GridLength(40))],
            ColumnSpacing = 5,
            HorizontalOptions = LayoutOptions.Fill,
            Padding = new Thickness(5, 0),
        };
        SetGridColumns(2);

        Image = new Image { HeightRequest = 40, Aspect = Aspect.AspectFit };

        TextEntry = new ExtEntry { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Center, Border = false, HorizontalTextAlignment = TextAlignment.End, FontSize = FormsSettings.ValueFontSize, TextColor = FormsSettings.ValueTextColor };
        TextEntry.SetBinding(Entry.TextProperty, "Text");

        Grid.Add(Image, 0);
        Grid.Add(TextEntry, 1);
    }
    #endregion

    #region Helper Methods
    protected void SetGridColumns(int count)
    {
        Grid.ColumnDefinitions.Clear();
        Grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        for (var i = 1; i < count; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        }
    }
    protected void SetGridRows(int count)
    {
        Grid.RowDefinitions.Clear();
        //Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        for (var i = 0; i < count; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
        }
    }
    #endregion


    #region Properties
    public Grid Grid
    {
        get => (Grid)View;
        set => View = value;
    }

    public ImageSource ImageSource
    {
        get => Image.Source;
        set => Image.Source = value;
    }
    public Image Image { get; set; }

    public virtual string Text
    {
        get => TextEntry.Text;
        set
        {
            if (value == TextEntry.Text) return;
            TextEntry.Text = value;
            OnPropertyChanged();
        }
    }
    public ExtEntry TextEntry { get; set; }

    public string Placeholder
    {
        get => TextEntry.Placeholder;
        set => TextEntry.Placeholder = value;
    }
    #endregion
}