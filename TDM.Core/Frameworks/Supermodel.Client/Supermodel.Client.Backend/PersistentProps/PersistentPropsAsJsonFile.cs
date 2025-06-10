using System.Diagnostics;
using Newtonsoft.Json;
using Supermodel.DataAnnotations.Exceptions;

namespace Supermodel.Client.Backend.PersistentProps;

public class PersistentPropsAsJsonFile : Dictionary<string, object>, IPersistentProps
{
    #region Constructors
    public PersistentPropsAsJsonFile(string fileName)
    {
        FileName = fileName;

        // ReSharper disable once VirtualMemberCallInConstructor
        var path = Path.Combine(GetDirectoryName(), FileName);
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            JsonConvert.PopulateObject(json, this);
        }
    }
    #endregion

    #region IPersistentProps implementation
    public Task ClearAsync()
    {
        Clear();
        return SaveToDiskAsync();
    }
    public Task RemoveAsync(string key)
    {
        Remove(key);
        return SaveToDiskAsync();
    }
    public Task SetAsync(string key, object value)
    {
        this[key] = value;
        return SaveToDiskAsync();
    }

    public new bool ContainsKey(string key)
    {
        return base.ContainsKey(key);
    }
    public T Get<T>(string key, T defaultValue)
    {
        if (ContainsKey(key)) return (T)base[key];
        return defaultValue;
    }
    public T Get<T>(string key)
    {
        if (ContainsKey(key)) return (T)base[key];
        throw new KeyNotFoundException(key);
    }
    #endregion

    #region Persistence
    public virtual string GetDirectoryName()
    {
        return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName) ?? throw new SupermodelException("Path.GetDirectoryName returned null");
    }
    public Task SaveToDiskAsync()
    {
        var json = JsonConvert.SerializeObject(this);
        var path = Path.Combine(GetDirectoryName(), FileName);
        return File.WriteAllTextAsync(path, json);
    }
    #endregion

    #region Properties
    [JsonIgnore] public string FileName { get; }
    #endregion
}