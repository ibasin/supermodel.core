using System.ComponentModel;

namespace Supermodel.Client.Backend.Models;

public interface ISupermodelNotifyPropertyChanged : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}