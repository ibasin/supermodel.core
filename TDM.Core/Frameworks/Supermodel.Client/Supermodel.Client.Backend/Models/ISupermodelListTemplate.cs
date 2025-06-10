namespace Supermodel.Client.Backend.Models;

public interface ISupermodelListTemplate : ISupermodelNotifyPropertyChanged
{
    DataTemplate GetListCellDataTemplate(EventHandler selectItemHandler, EventHandler deleteItemHandler);
}