using System.Net.Http.Headers;

namespace Supermodel.Mobile.Runtime.Backend.Multipart;

public class MultipartMemoryStreamProvider : MultipartStreamProvider
{
    public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
    {
        if (parent == null) throw new ArgumentNullException("parent");
        if (headers == null) throw new ArgumentNullException("headers");
        return new MemoryStream();
    }
}