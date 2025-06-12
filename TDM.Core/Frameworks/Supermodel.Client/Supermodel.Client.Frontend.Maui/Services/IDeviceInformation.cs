namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.Singleton]
[SharedService.ImplementedBy("", "")]
public interface IDeviceInformation
{
    bool IsRunningOnEmulator();
    bool? IsJailbroken(bool returnNullIfNotSupported);
    bool? IsDeviceSecuredByPasscode(bool returnNullIfNotSupported);
}