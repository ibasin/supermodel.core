namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.Singleton]
[SharedService.ImplementedBy("Supermodel.Client.Frontend.Maui.ImageResizer", "Supermodel.Client.Frontend.Maui.ImageResizer", "Supermodel.Client.Frontend.Maui.ImageResizer")]
public interface IImageResizer
{
    Task<byte[]> ResizeImageAsync(byte[] imageData, float maxWidth, float maxHeight);
}