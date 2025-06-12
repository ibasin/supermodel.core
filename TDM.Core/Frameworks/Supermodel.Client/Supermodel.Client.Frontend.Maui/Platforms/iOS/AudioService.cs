using AVFoundation;
using Foundation;
using Supermodel.Client.Frontend.Maui.Services;

// ReSharper disable once CheckNamespace
namespace Supermodel.Client.Frontend.Maui;

public class AudioService : IAudioService
{
    public void Play(byte[] wavSound)
    {
        if (_player == null || !_player.Playing)
        {
            _player = AVAudioPlayer.FromData(NSData.FromArray(wavSound));
            _player!.Play();
        }
    }

    //public void StartRecording()
    //{
    //    throw new System.NotImplementedException();
    //    //var recorder = new AVAudioRecorder();
    //    //recorder.
    //}

    //public byte[] StopRecording()
    //{
    //    throw new System.NotImplementedException();
    //}

    private static AVAudioPlayer? _player;
}