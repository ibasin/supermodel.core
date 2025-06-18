namespace Supermodel.Client.Frontend.Maui.UIComponents.Base;

public interface IWritableUIComponentViewModel : IReadOnlyUIComponentViewModel
{
    string? ErrorMessage { get; set; }
    bool Required { get; set; }
    object? WrappedValue { get; }
}