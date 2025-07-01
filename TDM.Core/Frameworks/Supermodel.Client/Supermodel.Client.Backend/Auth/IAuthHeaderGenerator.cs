using Supermodel.Encryptor;

namespace Supermodel.Client.Backend.Auth;

public interface IAuthHeaderGenerator
{
    long? UserId { get; set; }
    string UserLabel { get; set; }
    AuthHeader CreateAuthHeader();

    void Clear();
    Task ClearAndSaveToPropertiesAsync();
    bool LoadFromAppProperties();
    Task SaveToAppPropertiesAsync();
}