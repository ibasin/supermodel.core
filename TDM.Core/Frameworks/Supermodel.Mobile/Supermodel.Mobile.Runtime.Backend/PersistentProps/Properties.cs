using Supermodel.Mobile.Runtime.Backend.Services;

namespace Supermodel.Mobile.Runtime.Backend.PersistentProps;

public static class Properties
{
    #region Methods
    public static IPersistentProps Props
    {
        get
        {
            if (_dict == null)
            {
                _dict = Pick.ForPlatform<IPersistentProps>(new PersistentPropsAsMauiPreferences(),
                    new PersistentPropsAsMauiPreferences(),
                    new PersistentPropsAsJsonFile("props.json"));
            }
            return _dict;
        }
    }
    #endregion

    #region Propeties
    private static IPersistentProps? _dict;
    #endregion
}