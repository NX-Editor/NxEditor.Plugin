using NxEditor.PluginBase.Core.Services;

namespace NxEditor.PluginBase.Component;

public interface IEditor : IEditorInterface, IFormatService
{
    public bool HasChanged { get; }
}
