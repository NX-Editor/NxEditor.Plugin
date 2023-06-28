using Avalonia.Controls;
using Dock.Model.Mvvm.Controls;
using NxEditor.Plugin.Core.Models;
using NxEditor.Plugin.Core.Services;

namespace NxEditor.Plugin.Component;

public abstract class Editor<T, TView> : Document, IEditor, IFormatService where T : Editor<T, TView> where TView : UserControl, new()
{
    private static readonly Dictionary<string, IActionService> _actions = new();

    public Editor(IFileHandle handle)
    {
        FileHandle = handle;
        View = new() {
            DataContext = this
        };
    }

    public virtual bool HasChanged => false;
    public TView View { get; }
    public Dictionary<string, IActionService> Actions => _actions;
    public IFileHandle FileHandle { get; protected set; }

    public abstract Task Read(IFileHandle handle);
    public abstract Task<IFileHandle> Write();

    public virtual async Task Save(string? path)
    {
        StatusMgr.SetStatus($"Saving {typeof(T).Name}. . .", "fa-regular fa-floppy-disk");

        IFileHandle handle = await Write();
        foreach (var proc in handle.ProcessServices) {
            proc.Reprocess(handle);
        }

        FileHandle.Data = handle.Data;

        if (path is not null) {
            await File.WriteAllBytesAsync(path, handle.Data);
        }
    }
}
