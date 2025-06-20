using Supermodel.Client.Backend.Models;
using Supermodel.Client.Frontend.Maui.Models;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.FormModels;

[RMCopyAllPropsShallow]
public abstract class MauiFormModelFor<TModel> : MauiFormModelBase<TModel> where TModel : class, IModel, ISupermodelNotifyPropertyChanged, new()
{
    #region Constructors
    public virtual Task<MauiFormModelFor<TModel>> InitAsync(TModel model)
    {
        Model = model;
        return Task.FromResult(this);
    }
    #endregion
}