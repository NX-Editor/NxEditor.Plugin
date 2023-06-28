using NxEditor.Plugin.Core.Services;

namespace NxEditor.Plugin.Component;

public interface IEditor : IEditorInterface, IFormatService
{
    public bool HasChanged { get; }
}
