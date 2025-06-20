namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.ImplementedBy("Supermodel.Client.Frontend.Maui.AudioService", "Supermodel.Client.Frontend.Maui.AudioService")]
public interface IAudioService
{
    void Play(byte[] wavSound);
        
    //void StartRecording();
    //byte[] StopRecording();
}