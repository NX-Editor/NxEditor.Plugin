namespace NxEditor.PluginBase;

public abstract class ServiceExtension<T> : IServiceExtension where T : IServiceExtension, new()
{
    public static T Shared { get; } = new();

    IServiceExtension IServiceExtension.Shared => Shared;
    public abstract string Name { get; }

    public abstract void RegisterExtension(IServiceLoader serviceManager);
}
