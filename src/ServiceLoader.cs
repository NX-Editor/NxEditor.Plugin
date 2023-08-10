using NxEditor.PluginBase.Models;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase;

public class ServiceLoader : IServiceLoader
{
    public static ServiceLoader Shared { get; } = new();

    private readonly Dictionary<string, IServiceModule> _services = new();
    private readonly List<IProcessingService> _processors = new();

    public IFormatService RequestService(IFileHandle handle)
    {
        foreach (var processor in _processors) {
            if (processor.IsValid(handle)) {
                handle = processor.Process(handle);
                handle.ProcessServices.Add(processor);
            }
        }

        return SelectServiceDialog(handle)
            ?? throw new NotSupportedException("The provided IFileHandle is not a supported data type");
    }

    public IFormatService? SelectServiceDialog(IFileHandle handle)
    {
        IServiceModule[] providers = _services
            .Where(x => x.Value.IsValid(handle))
            .Select(x => x.Value)
            .ToArray();

        if (providers.Length <= 0) {
            return null;
        }

        return ((IFormatServiceProvider)providers[0])
            .GetService(handle);

        // TODO: Requires async context - https://github.com/AvaloniaUI/Avalonia/issues/12499

        // if (providers.Length == 1) {
        //     return ((IFormatServiceProvider)providers[0])
        //         .GetService(handle);
        // }
        // 
        // DialogBox dialog = new() {
        //     IsSecondaryButtonVisible = false,
        //     Content = new ListBox {
        //         Classes = { "Compact" },
        //         ItemsSource = providers,
        //         SelectionMode = SelectionMode.AlwaysSelected,
        //         ItemTemplate = new DataTemplate {
        //             DataType = typeof(IServiceModule),
        //             Content = new TextBlock {
        //                 [!TextBlock.TextProperty] = new Binding("Name")
        //             }
        //         }
        //     }
        // };
        // 
        // if (dialog.ShowAsync().WaitSynchronously() == DialogResult.Primary) {
        //     var provider = (IFormatServiceProvider)providers[((ListBox)dialog.Content).SelectedIndex];
        //     return provider.GetService(handle);
        // }
        // else {
        //     throw new ApplicationException("The operation was cancelled");
        // }
    }

    public T? RequestService<T>(string name) where T : class, IServiceModule => RequestService(name) as T;
    public IServiceModule? RequestService(string name)
    {
        return _services.TryGetValue(name, out var service) ? service : null;
    }

    public IServiceLoader Register(IProcessingService service)
    {
        _processors.Add(service);
        return this;
    }

    public IServiceLoader Register(string serviceId, IServiceModule service)
    {
        _services.Add(serviceId, service);
        return this;
    }
}
