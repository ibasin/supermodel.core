namespace Supermodel.Mobile.Runtime.Backend.Models;

public interface ISupermodelListTemplate : ISupermodelNotifyPropertyChanged
{
    DataTemplate GetListCellDataTemplate(EventHandler selectItemHandler, EventHandler deleteItemHandler);
}