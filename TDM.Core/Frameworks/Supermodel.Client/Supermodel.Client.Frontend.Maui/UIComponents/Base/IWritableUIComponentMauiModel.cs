namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public interface IWritableUIComponentMauiModel : IReadOnlyUIComponentMauiModel
{
    string? ErrorMessage { get; set; }
    bool Required { get; set; }
    object? WrappedValue { get; }
}