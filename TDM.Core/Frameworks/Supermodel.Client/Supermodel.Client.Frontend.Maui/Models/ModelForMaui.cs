using Supermodel.Client.Backend.Models;
using Supermodel.DataAnnotations.Exceptions;
using System.ComponentModel;

namespace Supermodel.Client.Frontend.Maui.Models;

public class ModelForMaui : Model, ISupermodelListTemplate
{
    #region ISupermodelListTemplate implemetation
    public virtual DataTemplate GetListCellDataTemplate(EventHandler? selectItemHandler, EventHandler? deleteItemHandler)
    {
        var dataTemplate = new DataTemplate(() =>
        {
            var cell = ReturnACell();
            //if delete item handler is not there, tap is not broken, so we don't need select item handler
            if (deleteItemHandler != null && selectItemHandler != null)
            {
                var selectAction = new MenuItem { Text = "Edit", Parent = cell };
                selectAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                cell.ContextActions.Add(selectAction);
                selectAction.Clicked += selectItemHandler;
            }
            if (deleteItemHandler != null)
            {
                var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
                deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                cell.ContextActions.Add(deleteAction);
                deleteAction.Clicked += deleteItemHandler;
            }
            return cell;
        });
        SetUpBindings(dataTemplate);
        return dataTemplate;
    }
    public virtual Cell ReturnACell()
    {
        var msg = $"In order to use '{GetType().Name}' class with CRUD features, you must override ReturnACell() and SetUpBindings() methods!";
        throw new SupermodelException(msg);
    }
    public virtual void SetUpBindings(DataTemplate dataTemplate)
    {
        var msg = $"In order to use '{GetType().Name}' class with CRUD features, you must override ReturnACell() and SetUpBindings() methods!";
        throw new SupermodelException(msg);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}