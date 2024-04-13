using CommunityToolkit.Mvvm.ComponentModel;

namespace NxEditor.PluginBase.ViewModels;

public partial class ItemSelectorViewModel(IEnumerable<string> items) : ObservableObject
{
    [ObservableProperty]
    private int _index;

    [ObservableProperty]
    private IEnumerable<string> _items = items;
}
