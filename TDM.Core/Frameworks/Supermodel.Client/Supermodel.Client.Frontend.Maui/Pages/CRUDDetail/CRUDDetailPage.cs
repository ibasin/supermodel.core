using System.Collections.ObjectModel;
using Supermodel.Client.Backend.DataContext.Core;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public abstract class CRUDDetailPage<TModelForMaui, TViewModelForMaui, TDataContext> : CRUDDetailPageBase<TModelForMaui, TViewModelForMaui, TDataContext>
    where TModelForMaui : class, ISupermodelNotifyPropertyChanged, IModel, new()
    where TViewModelForMaui : ViewModelForMauiFor<TModelForMaui>, new()
    where TDataContext : class, IDataContext, new()
{
    #region Initializers
    public virtual async Task<CRUDDetailPage<TModelForMaui, TViewModelForMaui, TDataContext>> InitAsync(ObservableCollection<TModelForMaui> models, string title, TModelForMaui model)
    {
        var xfModel = new TViewModelForMaui();
        await xfModel.InitAsync(model);
        xfModel = await xfModel.MapFromAsync(model);

        var originalXFModel = new TViewModelForMaui();
        await originalXFModel.InitAsync(model);
        originalXFModel = await originalXFModel.MapFromAsync(model);

        return (CRUDDetailPage<TModelForMaui, TViewModelForMaui, TDataContext>)await base.InitAsync(models, title, model, xfModel, originalXFModel);
    }
    #endregion

    #region Overrides
    protected override async Task<TViewModelForMaui> GetBlankXFModelAsync()
    {
        var blankModel = new TModelForMaui();
        var blankXfModel = (TViewModelForMaui) await new TViewModelForMaui().InitAsync(blankModel);
        return blankXfModel;
    }
    #endregion
}