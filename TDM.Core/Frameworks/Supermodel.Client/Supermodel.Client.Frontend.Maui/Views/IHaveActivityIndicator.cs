namespace Supermodel.Client.Frontend.Maui.Views;

public interface IHaveActivityIndicator
{
    Task WaitForPageToBecomeActiveAsync();
    bool ActivityIndicatorOn { get; set; }
    string Message { get; set; }
}