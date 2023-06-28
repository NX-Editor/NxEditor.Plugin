using NxEditor.PluginBase.Extensions;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase;

public interface IServiceLoader
{
    public IServiceLoader Register(string serviceId, IServiceModule service);
    public IServiceLoader Register(IExtensionModule extension);
}
