using Supermodel.Client.Maui.Backend.Models;
using Supermodel.Client.Maui.Backend.Repository;

namespace Supermodel.Client.Maui.Backend.DataContext.Core;

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