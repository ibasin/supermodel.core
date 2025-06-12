namespace Supermodel.Client.Frontend.Maui.Services;

[SharedService.Singleton]
public interface IImageResizer
{
    Task<byte[]> ResizeImageAsync(byte[] imageData, float maxWidth, float maxHeight);
}