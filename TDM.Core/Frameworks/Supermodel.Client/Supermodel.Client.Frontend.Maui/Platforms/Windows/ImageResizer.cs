//using System.Diagnostics.CodeAnalysis;
//using Supermodel.Client.Frontend.Maui.Services;
//using System.Drawing;
//using Image = Microsoft.Maui.Controls.Image;

//namespace Supermodel.Client.Frontend.Maui.Platforms.Windows;

//public class ImageResizer : IImageResizer
//{
//    public async Task<byte[]> ResizeImageAsync(byte[] imageData, float maxWidth, float maxHeight)
//    {
//        var result = await ResizeImageWindowsAsync(imageData, maxWidth, maxHeight);
//        return result;
//    }
//    [SuppressMessage("ReSharper", "IdentifierTypo")] 
//    [SuppressMessage("ReSharper", "InconsistentNaming")]
//    private Task<byte[]> ResizeImageWindowsAsync(byte[] imageData, float width, float height)
//    {
//        var destRect = new Rectangle(0, 0, (int)width, (int)height);
//        var destImage = new Bitmap((int)width, (int)height);

//        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

//        using (var graphics = Graphics.FromImage(destImage))
//        {
//            graphics.CompositingMode = CompositingMode.SourceCopy;
//            graphics.CompositingQuality = CompositingQuality.HighQuality;
//            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
//            graphics.SmoothingMode = SmoothingMode.HighQuality;
//            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

//            using (var wrapMode = new ImageAttributes())
//            {
//                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
//                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
//            }
//        }

//        return CopyImageToByteArray(destImage);
//    }
//    //private static byte[] CopyImageToByteArray(Image theImage)
//    //{
//    //    using (MemoryStream memoryStream = new MemoryStream())
//    //    {
//    //        theImage.Save(memoryStream, ImageFormat.Png);
//    //        return memoryStream.ToArray();
//    //    }
//    //}
//    //public static byte[] CopyImageToByteArray(Image x)
//    //{
//    //    ImageConverter _imageConverter = new ImageConverter();
//    //    byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
//    //    return xByte;
//    //}
//    //private static Bitmap GetImageFromByteArray(byte[] byteArray)
//    //{
//    //    Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray)!;

//    //    if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
//    //                       bm.VerticalResolution != (int)bm.VerticalResolution))
//    //    {
//    //        // Correct a strange glitch that has been observed in the test program when converting 
//    //        //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
//    //        //  slightly away from the nominal integer value
//    //        bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
//    //            (int)(bm.VerticalResolution + 0.5f));
//    //    }

//    //    return bm;
//    //}
//    //private static readonly ImageConverter _imageConverter = new ImageConverter();
//}