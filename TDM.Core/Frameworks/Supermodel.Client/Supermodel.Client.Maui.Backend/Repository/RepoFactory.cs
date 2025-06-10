using Supermodel.Client.Maui.Backend.Models;
using Supermodel.Client.Maui.Backend.UnitOfWork;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Maui.Backend.Repository;

public static class RepoFactory
{
    public static IDataRepo<TModel> Create<TModel>() where TModel : class, IModel, new()
    {
        return UnitOfWorkContextCore.CurrentDataContext.CreateRepo<TModel>();
    }
    public static object CreateForRuntimeType(Type modelType)
    {
        return ReflectionHelper.ExecuteStaticGenericMethod(typeof(RepoFactory), "Create", [modelType])!;
    }
}