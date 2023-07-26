namespace NxEditor.PluginBase;

public class Fontend
{
    private static readonly Dictionary<Type, object> _services = new();

    public static void Register<T>() where T : class, new() => Register(new T());
    public static void Register<T>(T service) where T : class
    {
        _services.Add(typeof(T), service);
    }

    public static T? Locate<T>() where T : class
    {
        return _services[typeof(T)] as T;
    }
}
