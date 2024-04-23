using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace NxEditor.PluginBase.Components;

public interface IFooterFactory
{
    public ObservableCollection<Control> Items { get; set; }

    public IFooterFactory Remove<T>() where T : class;
    public IFooterFactory Remove(Type type);
    public IFooterFactory Append<T>(T source) where T : class;
    public IFooterFactory Append(object source);
}
