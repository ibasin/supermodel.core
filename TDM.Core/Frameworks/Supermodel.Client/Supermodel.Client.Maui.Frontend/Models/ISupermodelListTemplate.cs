namespace Supermodel.Client.Maui.Frontend.Models;

public interface ISupermodelListTemplate : ISupermodelNotifyPropertyChanged
{
    DataTemplate GetListCellDataTemplate(EventHandler selectItemHandler, EventHandler deleteItemHandler);
}