namespace Supermodel.Client.Frontend.Maui;

public static class FormsSettings
{
    public static int LabelFontSize { get; set; } = 14;
    public static Color LabelTextColor { get; set; } = Colors.RoyalBlue;
    public static Color RequiredLabelTextColor { get; set; } = Colors.DarkRed;
    public static Color ValidationErrorColor { get; set; } = Colors.Red;

    public static int ValueFontSize { get; set; } = 14;
    public static Color ValueTextColor { get; set; } = Colors.Black;

    public static Color DisabledTextColor { get; set; } = Colors.LightGray;
    public static Color SwitchOnColor { get; set; } = Colors.RoyalBlue;

    public static int MultiLineTextBoxCellHeight { get; set; } = 120;

    public static string? AddNewImageFileName { get; set; }

    public static int MultiLineTextLabelHeight { get; set; } = 40;
}