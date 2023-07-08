using Avalonia.Controls;
using Dock.Model.Mvvm.Controls;
using NxEditor.PluginBase.Models;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Component;

public abstract class Editor<T, TView> : Document, IEditor, IFormatService, IDisposable where T : Editor<T, TView> where TView : UserControl, new()
{
    private static readonly Dictionary<string, IActionService> _actions = new();

    public Editor(IFileHandle handle)
    {
        Id = handle.Path ?? handle.Name;
        Title = handle.Name;

        Handle = handle;
        View = new() {
            DataContext = this
        };
    }

    public virtual bool HasChanged => false;
    UserControl IEditor.View => View;

    public TView View { get; }
    public Dictionary<string, IActionService> Actions => _actions;
    public IFileHandle Handle { get; protected set; }
    public abstract string[] ExportExtensions { get; }

    public abstract Task Read();
    public abstract Task<IFileHandle> Write();

    public virtual async Task Save(string? path)
    {
        StatusMgr.Set($"Saving {typeof(T).Name}. . .", "fa-regular fa-floppy-disk");

        IFileHandle handle = await Write();
        foreach (var proc in handle.ProcessServices) {
            proc.Reprocess(handle);
        }

        Handle.Data = handle.Data;

        if (path is not null) {
            await File.WriteAllBytesAsync(path, handle.Data);
        }
    }

    #pragma warning disable CA1816
    public virtual void Dispose() { }
}
