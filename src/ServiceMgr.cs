using ConfigFactory.Core;
using NxEditor.PluginBase.Models;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase;

public class ServiceMgr : IServiceLoader
{
    public static ServiceMgr Shared { get; } = new();

    private readonly Dictionary<string, IServiceModule> _services = new();

    public IFormatService RequestService(IFileHandle handle)
    {
        foreach ((_, var service) in _services.Where(x => x.Value.IsValid(handle)).OrderBy(x => x.Value is IProcessingService)) {
            if (service is IProcessingService proc) {
                handle = proc.Process(handle);
                handle.ProcessServices.Add(proc);
                continue;
            }

            return ((IFormatServiceProvider)service).GetService(handle);
        }

        throw new NotSupportedException("The provided IFileHandle is not a supported data type");
    }

    public T? RequestService<T>(string name) where T : class, IServiceModule => RequestService(name) as T;
    public IServiceModule? RequestService(string name)
    {
        return _services.TryGetValue(name, out var service) ? service : null;
    }

    public IServiceLoader Register(string serviceId, IServiceModule service)
    {
        _services.Add(serviceId, service);
        return this;
    }

    public IServiceLoader Register(IConfigModule config)
    {
        return this;
    }
}
