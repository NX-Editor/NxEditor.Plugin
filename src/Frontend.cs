namespace NxEditor.PluginBase;

/// <summary>
/// Frontend dependency injection manager
/// </summary>
public class Frontend
{
    private static readonly Dictionary<Type, object> _services = new();

    public static void Register<T>() where T : class, new() => Register(new T());
    public static void Register<T>(T service) where T : class
    {
        _services.Add(typeof(T), service);
    }

    public static T Locate<T>() where T : class
    {
        return _services[typeof(T)] as T
            ?? throw new ApplicationException($"Could not locate '{typeof(T).Name}' from Frontend");
    }
}
