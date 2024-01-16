using NxEditor.PluginBase.Services;
using System.Collections.ObjectModel;

namespace NxEditor.PluginBase.Models;

public delegate void WriteEditorFile(ref Span<byte> data);

public interface IEditorFile
{
    /// <summary>
    /// The unique id of the <see cref="IEditorFile"/>
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The display name of the <see cref="IEditorFile"/>
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The source data
    /// </summary>
    public byte[] Source { get; set; }

    /// <summary>
    /// The delegate to save the <see cref="IEditorFile"/>
    /// </summary>
    public WriteEditorFile Write { get; }

    /// <summary>
    /// Collection of processing services to use when saving
    /// </summary>
    public ObservableCollection<ITransformer> Services { get; }
}
