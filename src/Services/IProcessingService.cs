using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Services;

/// <summary>
/// Processes the request <see cref="IFileHandle"/> before being sent to a <see cref="IFormatService"/>
/// </summary>
public interface IProcessingService : IServiceModule
{
    /// <summary>
    /// Converts processed data to raw data and returns the result
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public void Process(IEditorFile handle);

    /// <summary>
    /// Reprocesses raw data and returns the result
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public void Reprocess(IEditorFile handle);
}
