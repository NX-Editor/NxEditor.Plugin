using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Components;

public interface IEditorManager
{
    public IEditor? Current { get; }
    public Task<bool> TryLoadEditor(IFileHandle handle);
    public Task LoadEditor(IFileHandle handle);
}
