using Supermodel.DataAnnotations.Exceptions;

namespace Supermodel.Client.Frontend.Maui.Services;

public enum Platform { IOS, Droid, DotNet, Mac }

public static class Pick
{
    public static Platform RunningPlatform()
    {
        return ForPlatform(Platform.IOS, Platform.Droid, Platform.DotNet, Platform.Mac);
    }
        
    public static T ForPlatform<T>(T iOS, T droid)
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS) return iOS;
        if (DeviceInfo.Platform == DevicePlatform.Android) return droid;
        
        throw new SupermodelException($"Unsupported Platform {DeviceInfo.Platform}");
    }

    public static T ForPlatform<T>(T iOS, T droid, T dotNet)
    {
        if (DeviceInfo.Platform == DevicePlatform.WinUI) return dotNet;
        return ForPlatform(iOS, droid);
    }

    public static T ForPlatform<T>(T iOS, T droid, T dotNet, T mac)
    {
        if (DeviceInfo.Platform == DevicePlatform.MacCatalyst) return mac;
        return ForPlatform(iOS, droid, dotNet);
    }
}