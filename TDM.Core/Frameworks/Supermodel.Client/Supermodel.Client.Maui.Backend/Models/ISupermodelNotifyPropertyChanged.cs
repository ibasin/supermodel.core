using System.ComponentModel;

namespace Supermodel.Client.Maui.Backend.Models;

public interface ISupermodelNotifyPropertyChanged : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}