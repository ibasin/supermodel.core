namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.ImplementedBy("Supermodel.Client.Frontend.Maui.iOS.AudioService", "Supermodel.Client.Frontend.Maui.Android.AudioService")]
public interface IAudioService
{
    void Play(byte[] wavSound);
        
    //void StartRecording();
    //byte[] StopRecording();
}