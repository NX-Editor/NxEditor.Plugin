using NxEditor.PluginBase.Models;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase;

public class ServiceLoader : IServiceLoader
{
    public static ServiceLoader Shared { get; } = new();

    private readonly Dictionary<string, IServiceModule> _services = new();
    private readonly List<IProcessingService> _processors = new();

    public IFormatService RequestService(IFileHandle handle)
    {
        foreach (var processor in _processors) {
            if (processor.IsValid(handle)) {
                handle = processor.Process(handle);
                handle.ProcessServices.Add(processor);
            }
        }

        try {
            return ((IFormatServiceProvider)_services
                .First(x => x.Value.IsValid(handle)).Value)
                .GetService(handle);
        }
        catch (Exception ex) {
            throw new NotSupportedException("The provided IFileHandle is not a supported data type", ex);
        }
    }

    public T? RequestService<T>(string name) where T : class, IServiceModule => RequestService(name) as T;
    public IServiceModule? RequestService(string name)
    {
        return _services.TryGetValue(name, out var service) ? service : null;
    }

    public IServiceLoader Register(IProcessingService service)
    {
        _processors.Add(service);
        return this;
    }

    public IServiceLoader Register(string serviceId, IServiceModule service)
    {
        _services.Add(serviceId, service);
        return this;
    }
}
