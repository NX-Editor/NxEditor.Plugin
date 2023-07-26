using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Components;

public interface IEditorManager
{
    public IEditor? Current { get; }
    public bool TryLoadEditor(IFileHandle handle);
    public void LoadEditor(IFileHandle handle);
}
