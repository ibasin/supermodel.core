using Supermodel.Client.Backend.Models;
using Supermodel.Client.Maui.Frontend.Models;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Maui.Frontend.XForms.ViewModels;

[RMCopyAllPropsShallow]
public abstract class XFModelForModel<TModel> : XFModelForModelBase<TModel> where TModel : class, IModel, ISupermodelNotifyPropertyChanged, new()
{
    #region Constructors
    public virtual Task<XFModelForModel<TModel>> InitAsync(TModel model)
    {
        Model = model;
        return Task.FromResult(this);
    }
    #endregion
}