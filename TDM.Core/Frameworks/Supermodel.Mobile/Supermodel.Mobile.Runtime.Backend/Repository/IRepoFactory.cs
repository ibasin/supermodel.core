using Supermodel.Mobile.Runtime.Backend.Models;

namespace Supermodel.Mobile.Runtime.Backend.Repository;

public interface IRepoFactory
{
    IDataRepo<TModel>? CreateRepo<TModel>() where TModel : class, IModel, new();
}