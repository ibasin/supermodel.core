using Supermodel.Mobile.Runtime.Backend.Models;
using Supermodel.Mobile.Runtime.Backend.Repository;

namespace Supermodel.Mobile.Runtime.Backend.DataContext.Core;

public interface IDataContext : IAsyncDisposable
{
    #region Configuration
    bool CommitOnDispose { get; set; }
    bool IsReadOnly { get; }
    void MakeReadOnly();
    #endregion

    #region Context RepoFactory
    IDataRepo<TModel> CreateRepo<TModel>() where TModel : class, IModel, new();
    #endregion

    #region CustomValues
    Dictionary<string, object> CustomValues { get; } 
    #endregion
}