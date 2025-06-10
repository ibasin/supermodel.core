using Supermodel.Client.Maui.Backend.Services;

namespace Supermodel.Client.Maui.Backend.PersistentProps;

public static class Properties
{
    #region Methods
    public static IPersistentProps Data
    {
        get
        {
            if (_props == null)
            {
                _props = Pick.ForPlatform<IPersistentProps>(new PersistentPropsAsMauiPreferences(),
                    new PersistentPropsAsMauiPreferences(),
                    new PersistentPropsAsJsonFile("props.json"));
            }
            return _props;
        }
    }
    #endregion

    #region Propeties
    private static IPersistentProps? _props;
    #endregion
}