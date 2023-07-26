﻿using Avalonia.Controls;
using Dock.Model.Mvvm.Controls;
using NxEditor.PluginBase.Models;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Components;

public abstract class Editor<T, TView> : Document, IEditor, IEditorInterface, IFormatService where T : Editor<T, TView> where TView : Control, new()
{
    private static readonly Dictionary<string, IActionService> _actions = new();

    public Editor(IFileHandle handle)
    {
        Id = handle.FilePath ?? handle.Name;
        Title = handle.Name;

        Handle = handle;
        View = new() {
            DataContext = this
        };
    }

    public virtual bool HasChanged => false;
    Control IEditor.View => View;

    public TView View { get; }
    public Dictionary<string, IActionService> Actions => _actions;
    public IFileHandle Handle { get; protected set; }
    public abstract string[] ExportExtensions { get; }

    public abstract Task Read();
    public abstract Task<IFileHandle> Write();

    public virtual async Task Save(string? path)
    {
        StatusModal.Set($"Saving {Title}", "fa-regular fa-floppy-disk");

        IFileHandle handle = await Write();
        foreach (var proc in handle.ProcessServices) {
            proc.Reprocess(handle);
        }

        Handle.Data = handle.Data;

        if (path is not null) {
            await File.WriteAllBytesAsync(path, handle.Data);
        }

        StatusModal.Set($"Saved {Title} Sucessfully", "fa-regular fa-floppy-disk", false, 2);
    }

    public virtual Task Undo() => Task.CompletedTask;
    public virtual Task Redo() => Task.CompletedTask;

    public virtual Task SelectAll() => Task.CompletedTask;
    public virtual Task Cut() => Task.CompletedTask;
    public virtual Task Copy() => Task.CompletedTask;
    public virtual Task Paste() => Task.CompletedTask;

    public virtual Task Find() => Task.CompletedTask;
    public virtual Task FindAndReplace() => Task.CompletedTask;

    public virtual void Activate() { }
    public virtual void Cleanup() { }

    public override bool OnClose()
    {
        Cleanup();
        return base.OnClose();
    }
}
