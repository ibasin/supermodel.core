namespace Supermodel.Client.Maui.Frontend.PersistentProps;

public class PersistentPropsAsMauiPreferences : IPersistentProps
{
    #region IPersistentProps implementation
    public Task ClearAsync()
    {
        Preferences.Default.Clear();
        return Task.CompletedTask;
    }
    public Task RemoveAsync(string key)
    {
        Preferences.Default.Remove(key);
        return Task.CompletedTask;
    }
    public Task SetAsync(string key, object value)
    {
        Preferences.Default.Set(key, value);
        return Task.CompletedTask;
    }

    public bool ContainsKey(string key)
    {
        return Preferences.Default.ContainsKey(key);
    }
    public T Get<T>(string key, T defaultValue)
    {
        return Preferences.Default.Get(key, defaultValue);
    }
    public T Get<T>(string key)
    {
        if (Preferences.Default.ContainsKey(key)) return Preferences.Default.Get(key, default(T)!);
        throw new KeyNotFoundException(key);
    }
    #endregion
}