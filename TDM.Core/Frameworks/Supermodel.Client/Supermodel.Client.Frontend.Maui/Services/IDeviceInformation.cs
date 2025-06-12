namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.Singleton]
[SharedService.ImplementedBy("Supermodel.Client.Frontend.Maui.iOS.DeviceInformation", "Supermodel.Client.Frontend.Maui.Android.DeviceInformation")]
public interface IDeviceInformation
{
    bool IsRunningOnEmulator();
    bool? IsJailbroken(bool returnNullIfNotSupported);
    bool? IsDeviceSecuredByPasscode(bool returnNullIfNotSupported);
}