using System.ComponentModel;

namespace Supermodel.Mobile.Runtime.Backend.Models;

public interface ISupermodelNotifyPropertyChanged : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}