using NxEditor.PluginBase.Core.Models;

namespace NxEditor.PluginBase.Core.Services;

/// <summary>
/// Handles an <see cref="IFileHandle"/> request as a file format specification
/// </summary>
public interface IFormatServiceProvider : IServiceModule
{
    public IFormatService GetService(IFileHandle handle);
}
