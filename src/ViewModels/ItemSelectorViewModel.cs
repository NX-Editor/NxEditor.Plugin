using CommunityToolkit.Mvvm.ComponentModel;

namespace NxEditor.PluginBase.ViewModels;

public partial class ItemSelectorViewModel : ObservableObject
{
    [ObservableProperty]
    private int _index;

    [ObservableProperty]
    private IEnumerable<string> _items;

    public ItemSelectorViewModel(IEnumerable<string> items)
    {
        _items = items;
    }
}
