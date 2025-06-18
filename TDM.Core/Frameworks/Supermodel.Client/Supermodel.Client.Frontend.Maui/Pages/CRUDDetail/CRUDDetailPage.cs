using System.Collections.ObjectModel;
using Supermodel.Client.Backend.DataContext.Core;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public abstract class CRUDDetailPage<TMauiModel, TMauiViewModel, TDataContext> : CRUDDetailPageBase<TMauiModel, TMauiViewModel, TDataContext>
    where TMauiModel : class, ISupermodelNotifyPropertyChanged, IModel, new()
    where TMauiViewModel : MauiViewModelFor<TMauiModel>, new()
    where TDataContext : class, IDataContext, new()
{
    #region Initializers
    public virtual async Task<CRUDDetailPage<TMauiModel, TMauiViewModel, TDataContext>> InitAsync(ObservableCollection<TMauiModel> models, string title, TMauiModel model)
    {
        var xfModel = new TMauiViewModel();
        await xfModel.InitAsync(model);
        xfModel = await xfModel.MapFromAsync(model);

        var originalXFModel = new TMauiViewModel();
        await originalXFModel.InitAsync(model);
        originalXFModel = await originalXFModel.MapFromAsync(model);

        return (CRUDDetailPage<TMauiModel, TMauiViewModel, TDataContext>)await base.InitAsync(models, title, model, xfModel, originalXFModel);
    }
    #endregion

    #region Overrides
    protected override async Task<TMauiViewModel> GetBlankXFModelAsync()
    {
        var blankModel = new TMauiModel();
        var blankXfModel = (TMauiViewModel) await new TMauiViewModel().InitAsync(blankModel);
        return blankXfModel;
    }
    #endregion
}