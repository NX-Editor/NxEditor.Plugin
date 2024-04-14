using NxEditor.PluginBase.Models;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase;

public interface IServiceLoader
{
    Task<IFormatService> RequestService(IEditorFile handle);
    T? GetFirstService<T>(IEditorFile handle) where T : class, IFormatService;
    IFormatService? GetFirstService(IEditorFile handle);
    IServiceModule? GetService(string name);
    IEnumerable<IFormatService> GetServices(IEditorFile handle);
    T? GetService<T>(string name) where T : class, IServiceModule;

    IServiceLoader Register(ITransformer service);
    IServiceLoader Register(string serviceId, IServiceModule service);
}
