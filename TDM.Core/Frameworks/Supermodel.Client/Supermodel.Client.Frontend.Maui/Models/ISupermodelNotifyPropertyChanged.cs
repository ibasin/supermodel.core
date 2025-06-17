using System.ComponentModel;

namespace Supermodel.Client.Frontend.Maui.Models;

public interface ISupermodelNotifyPropertyChanged : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}