namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public interface IWritableUIComponentFormModel : IReadOnlyUIComponentFormModel
{
    string? ErrorMessage { get; set; }
    bool Required { get; set; }
    object? WrappedValue { get; }
}