using Supermodel.Client.Maui.Backend.DataContext.WebApi;
using Supermodel.Client.Maui.Backend.Models;
using Supermodel.Encryptor;

namespace Supermodel.Client.Maui.Backend.DataContext.Core;

public interface IWebApiAuthorizationContext
{
    AuthHeader? AuthHeader { get; set; }
    Task<LoginResult> ValidateLoginAsync<TModel>() where TModel : class, IModel;
}