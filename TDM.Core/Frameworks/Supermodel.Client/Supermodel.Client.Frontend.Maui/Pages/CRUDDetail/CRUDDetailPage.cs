using System.Collections.ObjectModel;
using Supermodel.Client.Backend.DataContext.Core;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.Client.Frontend.Maui.FormModels;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.Pages.CRUDDetail;

public abstract class CRUDDetailPage<TMauiModel, TMauiFormModel, TDataContext> : CRUDDetailPageBase<TMauiModel, TMauiFormModel, TDataContext>
    where TMauiModel : class, ISupermodelNotifyPropertyChanged, IModel, new()
    where TMauiFormModel : MauiFormModelFor<TMauiModel>, new()
    where TDataContext : class, IDataContext, new()
{
    #region Initializers
    public virtual async Task<CRUDDetailPage<TMauiModel, TMauiFormModel, TDataContext>> InitAsync(ObservableCollection<TMauiModel> models, string title, TMauiModel model)
    {
        var formModel = new TMauiFormModel();
        await formModel.InitAsync(model);
        formModel = await formModel.MapFromAsync(model);

        var originalFormModel = new TMauiFormModel();
        await originalFormModel.InitAsync(model);
        originalFormModel = await originalFormModel.MapFromAsync(model);

        return (CRUDDetailPage<TMauiModel, TMauiFormModel, TDataContext>)await base.InitAsync(models, title, model, formModel, originalFormModel);
    }
    #endregion

    #region Overrides
    protected override async Task<TMauiFormModel> GetBlankFormModelAsync()
    {
        var blankModel = new TMauiModel();
        var blankFormModel = (TMauiFormModel) await new TMauiFormModel().InitAsync(blankModel);
        return blankFormModel;
    }
    #endregion
}