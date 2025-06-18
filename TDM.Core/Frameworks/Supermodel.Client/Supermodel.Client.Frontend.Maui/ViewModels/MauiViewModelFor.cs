using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.ViewModels;

[RMCopyAllPropsShallow]
public abstract class MauiViewModelFor<TModel> : MauiViewModelForBase<TModel> where TModel : class, IModel, ISupermodelNotifyPropertyChanged, new()
{
    #region Constructors
    public virtual Task<MauiViewModelFor<TModel>> InitAsync(TModel model)
    {
        Model = model;
        return Task.FromResult(this);
    }
    #endregion
}