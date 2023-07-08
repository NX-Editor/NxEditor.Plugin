using ConfigFactory.Core;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase;

public interface IServiceLoader
{
    public IServiceLoader Register(string serviceId, IServiceModule service);
    public IServiceLoader Register(IConfigModule config);
}
