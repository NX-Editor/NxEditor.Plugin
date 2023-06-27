using NxEditor.Plugin.Core.Services;

namespace NxEditor.Plugin.Component;

/// <summary>
/// 
/// </summary>
public interface IEditorInterface : IFormatService
{
    public virtual Task Save() => Save(FileHandle.Path);
    public Task Save(string? path);

    public virtual Task SelectAll() => Task.CompletedTask;
    public virtual Task Cut() => Task.CompletedTask;
    public virtual Task Copy() => Task.CompletedTask;
    public virtual Task Paste() => Task.CompletedTask;

    public virtual Task Find() => Task.CompletedTask;
    public virtual Task FindAndReplace() => Task.CompletedTask;
}
