using Supermodel.Client.Backend.DataContext.Core;
using Supermodel.Client.Backend.UnitOfWork;
using Supermodel.Client.Maui.Frontend.XForms.Pages.Login;

namespace Supermodel.Client.Maui.Frontend.XForms.App;

public abstract class SupermodelXamarinFormsApp : Application
{
    protected SupermodelXamarinFormsApp()
    {
        FormsApplication.SetRunningApp(this); 
    }

    public IAuthHeaderGenerator AuthHeaderGenerator { get; set; }
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
}