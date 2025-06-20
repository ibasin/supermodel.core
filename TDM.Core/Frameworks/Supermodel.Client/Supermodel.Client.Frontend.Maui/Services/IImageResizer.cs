namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.Singleton]
[SharedService.ImplementedBy("Supermodel.Client.Frontend.Maui.iOS.ImageResizer", "Supermodel.Client.Frontend.Maui.Android.ImageResizer", "Supermodel.Client.Frontend.Maui.Windows.ImageResizer")]
public interface IImageResizer
{
    Task<byte[]> ResizeImageAsync(byte[] imageData, float maxWidth, float maxHeight);
}