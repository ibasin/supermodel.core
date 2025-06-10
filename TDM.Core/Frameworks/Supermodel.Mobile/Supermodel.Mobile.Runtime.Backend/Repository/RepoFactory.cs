using Supermodel.Mobile.Runtime.Backend.Models;
using Supermodel.Mobile.Runtime.Backend.UnitOfWork;
using Supermodel.ReflectionMapper;

namespace Supermodel.Mobile.Runtime.Backend.Repository;

public static class RepoFactory
{
    public static IDataRepo<TModel> Create<TModel>() where TModel : class, IModel, new()
    {
        return UnitOfWorkContextCore.CurrentDataContext.CreateRepo<TModel>();
    }
    public static object? CreateForRuntimeType(Type modelType)
    {
        return ReflectionHelper.ExecuteStaticGenericMethod(typeof(RepoFactory), "Create", new[] { modelType });
    }
}