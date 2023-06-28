using NxEditor.PluginBase.Core.Extensions;
using NxEditor.PluginBase.Core.Services;

namespace NxEditor.PluginBase.Core;

public interface IServiceLoader
{
    public IServiceLoader Register(string serviceId, IServiceModule service);
    public IServiceLoader Register(IExtensionModule extension);
}
