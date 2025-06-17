using Supermodel.Client.Backend.DataContext.Core;
using Supermodel.Client.Backend.UnitOfWork;
using Supermodel.Client.Frontend.Maui.Pages.Login;

namespace Supermodel.Client.Frontend.Maui.App;

public abstract class SupermodelMauiApp : Application
{
    #region Comstructors
    protected SupermodelMauiApp()
    {
        ApplicationContext.SetRunningApp(this); 
    }
    #endregion

    #region virtual and abstract 
    public virtual UnitOfWork<TDataContext> NewUnitOfWork<TDataContext>(ReadOnly readOnly = ReadOnly.No) where TDataContext : class, IDataContext, new()
    {
        var unitOfWork = new UnitOfWork<TDataContext>(readOnly);
        if (unitOfWork.Context is IWebApiAuthorizationContext)
        {
            if (AuthHeaderGenerator != null) UnitOfWorkContext.AuthHeader = AuthHeaderGenerator.CreateAuthHeader();
        }
        return unitOfWork;
    }

    public abstract void HandleUnauthorized();
    public abstract byte[] LocalStorageEncryptionKey { get; }
    #endregion

    #region Properties
    public IAuthHeaderGenerator? AuthHeaderGenerator { get; set; }
    #endregion
}