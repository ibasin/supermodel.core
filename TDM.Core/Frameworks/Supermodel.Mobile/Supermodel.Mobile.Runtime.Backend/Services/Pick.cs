using System.Reflection;
using System.Runtime.Versioning;
using Supermodel.DataAnnotations.Exceptions;

namespace Supermodel.Mobile.Runtime.Backend.Services;

public static class Pick
{
    public static Platform RunningPlatform()
    {
        return ForPlatform(Platform.IOS, Platform.Droid, Platform.DotNetCore);
    }
        
    public static T ForPlatform<T>(T iOS, T droid)
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS) return iOS;
        if (DeviceInfo.Platform == DevicePlatform.Android) return droid;
        else throw new SupermodelException($"Unsupported Platform {DeviceInfo.Platform}");
    }

    public static T ForPlatform<T>(T iOS, T droid, T netCore)
    {
        var framework = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
        if (framework != null && framework.StartsWith(".NETCoreApp", StringComparison.Ordinal)) return netCore;
        else return ForPlatform(iOS, droid);
    }
}