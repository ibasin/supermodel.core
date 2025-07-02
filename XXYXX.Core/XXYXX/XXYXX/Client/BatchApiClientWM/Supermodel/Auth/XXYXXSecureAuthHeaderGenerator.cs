using System;
using Supermodel.Client.Backend.Auth;
using Supermodel.Encryptor;

namespace BatchApiClientWM.Supermodel.Auth;

public class XXYXXSecureAuthHeaderGenerator : BasicAuthHeaderGenerator
{
    #region Constructors
    public XXYXXSecureAuthHeaderGenerator(string username, string password) : base(username, password){}
    #endregion

    #region Overrides
    public override AuthHeader CreateAuthHeader()
    {
            var dateTimeSalt = HashAgent.Generate5MinTimeStampSalt(DateTime.UtcNow);
            var secretTokenHashSalt = HashAgent.GenerateGuidSalt();
            var secretTokenHash = HashAgent.HashPasswordSHA256(SecretToken + dateTimeSalt, secretTokenHashSalt);
            var authHeader = HttpAuthAgent.CreateSMCustomEncryptedAuthHeader(Key, Username, Password, secretTokenHash, secretTokenHashSalt);
            authHeader.HeaderName = HeaderName;
            return authHeader;
        }
    #endregion

    #region Shared Constants
    public static readonly byte[] Key = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
    public static readonly string HeaderName = "X-XXYXX-Authorization";
    // ReSharper disable StringLiteralTypo
    public static readonly string SecretToken = "[SECRET_TOKEN]";
    // ReSharper restore StringLiteralTypo
    #endregion
}