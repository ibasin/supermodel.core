using Supermodel.Client.Backend.DataContext.WebApi;
using Supermodel.Client.Backend.Models;
using Supermodel.Client.Backend.UnitOfWork;
using Supermodel.Client.Maui.Frontend.XForms.App;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.Login;

public abstract class LoginPageBase<TLoginViewModel, TLoginView, TLoginValidationModel, TWebApiDataContext> : LoginPageCore<TLoginViewModel, TLoginView>
    where TLoginViewModel: ILoginViewModel, new()
    where TLoginView : LoginViewBase<TLoginViewModel>, new()
    where TLoginValidationModel : class, IModel
    where TWebApiDataContext : WebApiDataContext, new()
{
    #region Overrides
    public override async Task<LoginResult> TryLoginAsync()
    {
        await using(FormsApplication.GetRunningApp().NewUnitOfWork<TWebApiDataContext>(ReadOnly.Yes))
        {
            return await UnitOfWorkContext.ValidateLoginAsync<TLoginValidationModel>();
        }
    }
    #endregion
}