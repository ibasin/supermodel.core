using System.ComponentModel;

namespace Supermodel.Client.Maui.Frontend.Models;

public interface ISupermodelNotifyPropertyChanged : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}