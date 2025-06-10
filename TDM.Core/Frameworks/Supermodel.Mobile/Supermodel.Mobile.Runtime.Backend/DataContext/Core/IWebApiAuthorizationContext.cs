using Supermodel.Encryptor;
using Supermodel.Mobile.Runtime.Backend.DataContext.WebApi;
using Supermodel.Mobile.Runtime.Backend.Models;

namespace Supermodel.Mobile.Runtime.Backend.DataContext.Core;

public interface IWebApiAuthorizationContext
{
    AuthHeader? AuthHeader { get; set; }
    Task<LoginResult> ValidateLoginAsync<TModel>() where TModel : class, IModel;
}