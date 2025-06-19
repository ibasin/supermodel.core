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
        var viewModel = new TMauiViewModel();
        await viewModel.InitAsync(model);
        viewModel = await viewModel.MapFromAsync(model);

        var originalViewModel = new TMauiViewModel();
        await originalViewModel.InitAsync(model);
        originalViewModel = await originalViewModel.MapFromAsync(model);

        return (CRUDDetailPage<TMauiModel, TMauiViewModel, TDataContext>)await base.InitAsync(models, title, model, viewModel, originalViewModel);
    }
    #endregion

    #region Overrides
    protected override async Task<TMauiViewModel> GetBlankViewModelAsync()
    {
        var blankModel = new TMauiModel();
        var blankViewModel = (TMauiViewModel) await new TMauiViewModel().InitAsync(blankModel);
        return blankViewModel;
    }
    #endregion
}