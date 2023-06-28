using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Component;

public interface IEditor : IEditorInterface, IFormatService
{
    public bool HasChanged { get; }
}
