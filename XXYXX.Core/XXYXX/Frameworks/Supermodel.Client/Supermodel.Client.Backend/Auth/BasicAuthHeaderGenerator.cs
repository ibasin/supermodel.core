using Supermodel.DataAnnotations.Exceptions;
using Supermodel.Encryptor;

namespace Supermodel.Client.Backend.Auth;

public class BasicAuthHeaderGenerator : IAuthHeaderGenerator
{
    #region Constructors
    public BasicAuthHeaderGenerator(string username, string password, byte[] localStorageEncryptionKey = null)
    {
        Username = username;
        Password = password;
        LocalStorageEncryptionKey = localStorageEncryptionKey;
    }
    #endregion
				
    #region Methods
    public virtual AuthHeader CreateAuthHeader()
    {
        return HttpAuthAgent.CreateBasicAuthHeader(Username, Password);
    }
    #endregion
				
    #region Properties
    public long? UserId { get; set; }
    public string UserLabel { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    private byte[] LocalStorageEncryptionKey { get; }
    #endregion
}