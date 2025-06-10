namespace Supermodel.Client.Maui.Backend.Models;

public interface ISupermodelListTemplate : ISupermodelNotifyPropertyChanged
{
    DataTemplate GetListCellDataTemplate(EventHandler selectItemHandler, EventHandler deleteItemHandler);
}