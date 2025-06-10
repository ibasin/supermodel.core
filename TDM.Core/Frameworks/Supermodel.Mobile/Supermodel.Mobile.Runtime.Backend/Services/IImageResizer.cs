namespace Supermodel.Mobile.Runtime.Backend.Services;

[SharedService.Singleton]
public interface IImageResizer
{
    Task<byte[]> ResizeImageAsync(byte[] imageData, float maxWidth, float maxHeight);
}