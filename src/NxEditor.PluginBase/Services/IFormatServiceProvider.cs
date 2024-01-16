using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Services;

/// <summary>
/// Handles an <see cref="IFileHandle"/> request as a file format specification
/// </summary>
public interface IFormatServiceProvider : IServiceModule
{
    public IFormatService GetService(IEditorFile handle);
}
