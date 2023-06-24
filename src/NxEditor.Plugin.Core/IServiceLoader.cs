using NxEditor.Plugin.Core.Extensions;
using NxEditor.Plugin.Core.Services;

namespace NxEditor.Plugin.Core;

public interface IServiceLoader
{
    public IServiceLoader Register(string serviceId, IServiceModule service);
    public IServiceLoader Register(IConfigExtension extension);
}
