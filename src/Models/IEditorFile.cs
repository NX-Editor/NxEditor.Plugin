using NxEditor.PluginBase.Services;
using System.Collections.ObjectModel;

namespace NxEditor.PluginBase.Models;

public delegate void WriteEditorFile(IEditorFile editorFile, Span<byte> data);
public delegate Span<byte> ReadEditorFile(IEditorFile editorFile);

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
    /// The delegate to read the <see cref="IEditorFile"/>
    /// </summary>
    public ReadEditorFile Read { get; set; }

    /// <summary>
    /// The delegate to save the <see cref="IEditorFile"/>
    /// </summary>
    public WriteEditorFile Write { get; set; }

    /// <summary>
    /// Collection of processing services to use when saving
    /// </summary>
    public ObservableCollection<IProcessingService> Services { get; }
}
