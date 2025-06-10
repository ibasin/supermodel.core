namespace Supermodel.Client.Maui.Backend.Services;

public interface IAudioService
{
    void Play(byte[] wavSound);
        
    //void StartRecording();
    //byte[] StopRecording();
}