namespace Supermodel.Client.Maui.Backend.PersistentProps;

public interface IPersistentProps
{
    //writes
    Task ClearAsync();
    Task RemoveAsync(string key);
    Task SetAsync(string key, object value);

    //reads
    bool ContainsKey(string key);
    T Get<T>(string key, T defaultValue);
    T Get<T>(string key);
}