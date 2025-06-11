namespace Supermodel.Client.Maui.Frontend.XForms.Views;

public interface IHaveActivityIndicator
{
    Task WaitForPageToBecomeActiveAsync();
    bool ActivityIndicatorOn { get; set; }
    string Message { get; set; }
}