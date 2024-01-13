using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Components;

public interface IEditorManager
{
    public IEditor? Current { get; }
    public Task<bool> TryLoadEditor(IEditorFile handle);
    public Task LoadEditor(IEditorFile handle);
}
