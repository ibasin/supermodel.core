using Supermodel.Client.Backend.DataContext.WebApi;
using Supermodel.Client.Backend.Models;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.Login;

public abstract class UsernameAndPasswordLoginPage<TLoginValidationModel, TWebApiDataContext> : LoginPageBase<UsernameAndPasswordLoginViewModel, UsernameAndPasswordLoginView, TLoginValidationModel, TWebApiDataContext>
    where TLoginValidationModel : class, IModel
    where TWebApiDataContext : WebApiDataContext, new()
{}