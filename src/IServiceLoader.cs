using NxEditor.Plugin.Extensions;
using NxEditor.Plugin.Services;

namespace NxEditor.Plugin;

public interface IServiceLoader
{
    public IServiceLoader Register(string serviceId, IServiceModule service);
    public IServiceLoader Register(IConfigExtension extension);
}
