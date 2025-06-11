using Supermodel.Encryptor;

namespace Supermodel.Client.Maui.Frontend.XForms.Pages.Login;

public interface IAuthHeaderGenerator
{
    long? UserId { get; set; }
    string? UserLabel { get; set; }
    AuthHeader CreateAuthHeader();

    void Clear();
    void ClearAndSaveToPreferences();
    bool LoadFromPreferences();
    void SaveToPreferences();
}