using Android.Media;
using Java.IO;
using Supermodel.Client.Frontend.Maui.Services;

// ReSharper disable once CheckNamespace
namespace Supermodel.Client.Frontend.Maui.Android;

public class AudioService : IAudioService
{
    public void Play(byte[] wavSound)
    {
        if (_player == null || !_player.IsPlaying)
        {
            if (_player != null) _player.Release();
            var tempWav = Java.IO.File.CreateTempFile("temp", "wav", Microsoft.Maui.ApplicationModel.Platform.CurrentActivity!.CacheDir);
            // ReSharper disable once PossibleNullReferenceException
            tempWav.DeleteOnExit();
            var fos = new FileOutputStream(tempWav);
            fos.Write(wavSound);
            fos.Close();
		                
            _player = new MediaPlayer();
            var fis = new FileInputStream(tempWav);
            _player.SetDataSource(fis.FD);
		
            _player.Prepare();
            _player.Start();
        }        
    }
		
    private static MediaPlayer? _player; //AudioTrack
}