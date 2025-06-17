using System.Collections.ObjectModel;
using Supermodel.Client.Backend.DataContext.Core;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.ViewModels;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public abstract class CRUDDetailPage<TModel, TMauiModel, TDataContext> : CRUDDetailPageBase<TModel, TMauiModel, TDataContext>
    where TModel : class, ISupermodelNotifyPropertyChanged, IModel, new()
    where TMauiModel : MauiModelForModel<TModel>, new()
    where TDataContext : class, IDataContext, new()
{
    #region Initializers
    public virtual async Task<CRUDDetailPage<TModel, TMauiModel, TDataContext>> InitAsync(ObservableCollection<TModel> models, string title, TModel model)
    {
        var xfModel = new TMauiModel();
        await xfModel.InitAsync(model);
        xfModel = await xfModel.MapFromAsync(model);

        var originalXFModel = new TMauiModel();
        await originalXFModel.InitAsync(model);
        originalXFModel = await originalXFModel.MapFromAsync(model);

        return (CRUDDetailPage<TModel, TMauiModel, TDataContext>)await base.InitAsync(models, title, model, xfModel, originalXFModel);
    }
    #endregion

    #region Overrides
    protected override async Task<TMauiModel> GetBlankXFModelAsync()
    {
        var blankModel = new TModel();
        var blankXfModel = (TMauiModel) await new TMauiModel().InitAsync(blankModel);
        return blankXfModel;
    }
    #endregion
}