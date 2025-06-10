using Supermodel.Client.Maui.Backend.Models;

namespace Supermodel.Client.Maui.Backend.Repository;

public interface IRepoFactory
{
    IDataRepo<TModel>? CreateRepo<TModel>() where TModel : class, IModel, new();
}