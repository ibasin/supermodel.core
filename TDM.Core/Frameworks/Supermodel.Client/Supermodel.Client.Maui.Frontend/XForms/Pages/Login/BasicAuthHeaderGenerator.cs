using Supermodel.DataAnnotations.Exceptions;
using Supermodel.Encryptor;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.Login;

public class BasicAuthHeaderGenerator : IAuthHeaderGenerator
{
    #region Constructors
    public BasicAuthHeaderGenerator(string username, string password, byte[]? localStorageEncryptionKey = null)
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

    public virtual void Clear()
    {
        Username = Password = "";
    }
    public virtual void ClearAndSaveToPreferences()
    {
        if (LocalStorageEncryptionKey == null) throw new SupermodelException("ClearAndSaveToPreferences(): LocalStorageEncryptionKey = null");

        Clear();
        Preferences.Default.Set<string?>("smUsername", null);
        Preferences.Default.Set<byte[]?>("smPasswordCode", null);
        Preferences.Default.Set<byte[]?>("smPasswordIV", null);
    }
    public virtual void SaveToPreferences()
    {
        if (LocalStorageEncryptionKey == null) throw new SupermodelException("SaveToPreferences(): LocalStorageEncryptionKey = null");

        if  (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)) throw new SupermodelException("string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password)");

        var passwordCode = EncryptorAgent.Lock(LocalStorageEncryptionKey, Password, out var passwordIV);

        Preferences.Default.Set<string?>("smUsername", Username);
        Preferences.Default.Set<byte[]?>("smPasswordCode", passwordCode);
        Preferences.Default.Set<byte[]?>("smPasswordIV", passwordIV);

        // ReSharper disable RedundantTypeArgumentsOfMethod
        Preferences.Default.Set<string?>("smUserLabel", UserLabel);
        Preferences.Default.Set<long?>("smUserId", UserId);
        // ReSharper restore RedundantTypeArgumentsOfMethod
    }
    public virtual bool LoadFromPreferences()
    {
        if (LocalStorageEncryptionKey == null) throw new SupermodelException("LoadFromPreferences(): LocalStorageEncryptionKey = null");

        if (Preferences.Default.ContainsKey("smUsername") &&
            Preferences.Default.ContainsKey("smPasswordCode") &&
            Preferences.Default.ContainsKey("smPasswordIV") &&
            Preferences.Default.ContainsKey("smUserLabel") &&
            Preferences.Default.ContainsKey("smUserId"))
        {
            //username, passwordCode, passwordIV cant be null
            var username = Preferences.Default.Get<string?>("smUsername", null);
            if (string.IsNullOrEmpty(username)) return false;

            var passwordCode = Preferences.Default.Get<byte[]?>("smPasswordCode", null);
            if (passwordCode == null) return false;

            var passwordIV = Preferences.Default.Get<byte[]?>("smPasswordIV", null);
            if (passwordIV == null) return false;

            //User label and userId can be null
            var userLabel = Preferences.Default.Get<string?>("smUserLabel", null);
            var userId = Preferences.Default.Get<long?>("smUserId", null);

            Password = EncryptorAgent.Unlock(LocalStorageEncryptionKey, passwordCode, passwordIV);
            Username = username;
            UserLabel = userLabel;
            UserId = userId;
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
				
    #region Properties
    public long? UserId { get; set; }
    public string? UserLabel { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    private byte[]? LocalStorageEncryptionKey { get; }
    #endregion
}