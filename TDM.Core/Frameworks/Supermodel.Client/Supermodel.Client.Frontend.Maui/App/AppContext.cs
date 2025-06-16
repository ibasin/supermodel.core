using Supermodel.DataAnnotations.Exceptions;

namespace Supermodel.Client.Frontend.Maui.App;

public class AppContext<TApp> : AppContext where TApp : SupermodelMauiApp, new()
{
    public static TApp RunningApp => (TApp)(_runningApp ?? throw new SupermodelException("_runningApp not set"));
}
public class AppContext
{
    public static void SetRunningApp(SupermodelMauiApp runningApp) { _runningApp = runningApp; }
    public static SupermodelMauiApp GetRunningApp() { return _runningApp ?? throw new SupermodelException("_runningApp not set"); }
        
    // ReSharper disable once InconsistentNaming
    protected static SupermodelMauiApp? _runningApp;
}