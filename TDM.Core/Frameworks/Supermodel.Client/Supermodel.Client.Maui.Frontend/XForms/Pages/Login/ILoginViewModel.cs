using System.ComponentModel;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.Login;

public interface ILoginViewModel : INotifyPropertyChanged
{
    string GetValidationError();
}