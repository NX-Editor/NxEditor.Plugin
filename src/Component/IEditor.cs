using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Component;

public interface IEditor : IEditorInterface, IFormatService, IDisposable
{
    public bool HasChanged { get; }
}
