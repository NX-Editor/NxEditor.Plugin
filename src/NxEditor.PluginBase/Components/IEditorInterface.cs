using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Components;

/// <summary>
/// 
/// </summary>
public interface IEditorInterface : IFormatService
{
    public void Save() => Save(null);
    public void Save(string? path);

    public Task Undo();
    public Task Redo();

    public Task SelectAll();
    public Task Cut();
    public Task Copy();
    public Task Paste();

    public Task Find();
    public Task FindAndReplace();
}
