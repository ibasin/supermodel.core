using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebMonk.Exceptions;
using WebMonk;

namespace WebWM.Services;

public class XXYXXWebServer : WebServer
{
    #region Constructors
    public XXYXXWebServer(int httpPort, string navigationBaseUrl, Assembly[]? appAssemblies = null) 
        : base(httpPort, navigationBaseUrl, appAssemblies) { }
    #endregion

    #region Overrides
    protected override Task OnInternalServerErrorAsync(Exception ex)
    {
        if (Debugger.IsAttached) return base.OnInternalServerErrorAsync(ex);

        XXYXXWindowsService.Logger?.LogWarning(ex, ex.Message);

        // Log the exception and notify system operators
        //var request = HttpContext.Current.HttpListenerContext.Request;
        //Notifications.SendSystemMessageSMTP(CLPT2Config.SystemEmail, $"CLPT2: 500.Error serving a page {HttpContext.Current.HttpListenerContext.Request.Url}", $"{ex}\n\nIP: {request.RemoteEndPoint}\nX-Forwarded-For: {request.Headers["X-Forwarded-For"]}\nUser Agent: {request.UserAgent}\nReferer: {request.UrlReferrer}");
        return Task.CompletedTask;
    }
    protected override Task OnUnsupportedMediaTypeAsync(Exception415UnsupportedMediaType ex)
    {
        if (Debugger.IsAttached) return base.OnUnsupportedMediaTypeAsync(ex);

        XXYXXWindowsService.Logger?.LogWarning(ex, ex.Message);

        // Log the exception and notify system operators
        //var request = HttpContext.Current.HttpListenerContext.Request;
        //Notifications.SendSystemMessageSMTP(CLPT2Config.SystemEmail, $"CLPT2: 415.Error serving a page {HttpContext.Current.HttpListenerContext.Request.Url}", $"{ex}\n\nIP: {request.RemoteEndPoint}\nX-Forwarded-For: {request.Headers["X-Forwarded-For"]}\nUser Agent: {request.UserAgent}\nReferer: {request.UrlReferrer}");
        return Task.CompletedTask;
    }
    #endregion
}