using System.Collections.Concurrent;
using System.Reflection;
using Supermodel.DataAnnotations.Exceptions;
using Supermodel.ReflectionMapper;

namespace Supermodel.Client.Frontend.Maui.Services;

public static class SharedService
{
    #region EmbeddedTypes
    [AttributeUsage(AttributeTargets.Interface)]
    public class SingletonAttribute : Attribute{}

    [AttributeUsage(AttributeTargets.Interface)]
    public class ImplementedByAttribute : Attribute
    {
        #region Constructors
        public ImplementedByAttribute(string iosType, string androidType, string? dotNetType = null, string? macType = null)
        {
            IOSType = iosType ?? throw new ArgumentNullException(nameof(iosType));
            DroidType = androidType ?? throw new ArgumentNullException(nameof(androidType));
            DotNetType = dotNetType;
            MacType = macType;
        }
        #endregion

        #region Properties
        public string IOSType { get; }
        public string DroidType { get; }
        public string? DotNetType { get; }
        public string? MacType { get; }
        #endregion
    }
    #endregion

    #region Methods
    public static TInterface Instantiate<TInterface>(params object[] paramObjects) 
    {
        var interfaceType = typeof(TInterface);
        if (!interfaceType.IsInterface) throw new ArgumentException("Generic type T must be an interface");
        var singleton = interfaceType.GetCustomAttribute<SingletonAttribute>() != null;
            
        var typeName = GetClassToInstantiateFullName<TInterface>();           

        if (!singleton) return InstantiateByType<TInterface>(typeName, paramObjects);

        if (!Singletons.ContainsKey(interfaceType)) Singletons[interfaceType] = InstantiateByType<TInterface>(typeName, paramObjects)!;
        return (TInterface)Singletons[interfaceType];
    }
    private static TInterface InstantiateByType<TInterface>(string typeName, object[] paramObjects)
    {
        if (typeName == null) throw new ArgumentNullException(nameof(typeName));

        try
        {
            var typeType = Type.GetType(typeName) ?? throw new SystemException("Type.GetType(typeName) == null");
            return (TInterface)ReflectionHelper.CreateType(typeType, paramObjects);
        }
        catch (Exception ex)
        {
            throw new SupermodelException($"Unable to create type {typeName} or cast it to {typeof(TInterface).FullName}: {ex.Message}");
        }
    }

    public static string GetClassToInstantiateFullName<TInterface>()
    {
        return GetClassToInstantiateFullName(typeof(TInterface));
    }
    public static string GetClassToInstantiateFullName(Type interfaceType)
    {
        var implementedByAttr = interfaceType.GetCustomAttribute<ImplementedByAttribute>();
        if (implementedByAttr == null) throw new SupermodelException("GetClassToInstantiateFullName(): [ImplementedBy] attribute is not set");

        var typeName = Pick.ForPlatform(implementedByAttr.IOSType, implementedByAttr.DroidType, implementedByAttr.DotNetType, implementedByAttr.MacType);
        if (typeName == null) throw new SupermodelException("Unsupported Platform");

        return typeName;

        //if (implementedByAttr != null)
        //{
        //    typeName = Pick.ForPlatform(implementedByAttr.IOSType, implementedByAttr.DroidType, implementedByAttr.DotNetType, implementedByAttr.MacType);
        //    if (typeName == null) throw new SupermodelException("Unsupported Platform");
        //}
        //else
        //{
        //    var iTypeNamespace = interfaceType.Namespace ?? throw new SupermodelException("Can't determine namespace");

        //    string typeNamespace;
        //    if (iTypeNamespace.EndsWith(".Common")) 
        //    {
        //        typeNamespace = iTypeNamespace.Substring(0, iTypeNamespace.Length - ".Common".Length) + Pick.ForPlatform(".iOS.", ".Droid.", ".NetCore.");
        //    }
        //    else 
        //    {
        //        typeNamespace = iTypeNamespace.Replace(".Common.", Pick.ForPlatform(".iOS.", ".Droid.", ".NetCore."));
        //    }

        //    var iTypeName = interfaceType.Name;
        //    if (!iTypeName.StartsWith("I")) throw new ArgumentException("Generic type T must be an interface and start with 'I'");

        //    typeName = $"{typeNamespace}.{iTypeName.Substring(1, iTypeName.Length-1)}, Supermodel.Mobile.Runtime.{Pick.ForPlatform("iOS", "Droid", "NetCore")}";
        //}

        //return typeName;
    }
    #endregion

    #region Properties
    public static ConcurrentDictionary<Type, object> Singletons { get; } = new();
    #endregion
}