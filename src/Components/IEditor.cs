using Avalonia.Controls;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Components;

public interface IEditor : IEditorInterface, IFormatService, IDisposable
{
    public UserControl View { get; }
    public bool HasChanged { get; }
}
