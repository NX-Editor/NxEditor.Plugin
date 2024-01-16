using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Services;

/// <summary>
/// Mutate the request <see cref="IEditorFile"/> before being sent to a <see cref="IFormatService"/>
/// </summary>
public interface ITransformer : IServiceModule
{
    /// <summary>
    /// Mutates the <see cref="IEditorFile.Source"/> data
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public void TransformSource(IEditorFile handle);

    /// <summary>
    /// Mutates the passed in <paramref name="data"/> based on the <paramref name="handle"/>
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public void Transform(ref Span<byte> data, IEditorFile handle);
}
