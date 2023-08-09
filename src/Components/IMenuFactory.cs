using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace NxEditor.PluginBase.Components;

public interface IMenuFactory
{
    public ObservableCollection<Control> Items { get; set; }

    public IMenuFactory Prepend<T>() where T : class;
    public IMenuFactory Append<T>(T source) where T : class;
}
