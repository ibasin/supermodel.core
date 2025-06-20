namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.Singleton]
[SharedService.ImplementedBy("Supermodel.Client.Frontend.Maui.DeviceInformation", "Supermodel.Client.Frontend.Maui.DeviceInformation")]
public interface IDeviceInformation
{
    bool IsRunningOnEmulator();
    bool? IsJailbroken(bool returnNullIfNotSupported);
    bool? IsDeviceSecuredByPasscode(bool returnNullIfNotSupported);
}