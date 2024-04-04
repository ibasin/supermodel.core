using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebMonk.Exceptions;
using WebMonk;
using WebWM.WindowsService;

namespace WebWM;

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

        return Task.CompletedTask;
    }
    protected override Task OnUnsupportedMediaTypeAsync(Exception415UnsupportedMediaType ex)
    {
        if (Debugger.IsAttached) return base.OnUnsupportedMediaTypeAsync(ex);

        XXYXXWindowsService.Logger?.LogWarning(ex, ex.Message);

        return Task.CompletedTask;
    }
    #endregion
}