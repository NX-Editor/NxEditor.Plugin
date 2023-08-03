using CommunityToolkit.Mvvm.ComponentModel;
using ConfigFactory.Core;
using ConfigFactory.Core.Attributes;
using NxEditor.PluginBase.Extensions;
using System.Text.Json.Serialization;

namespace NxEditor.PluginBase;

public partial class GlobalConfig : ConfigModule<GlobalConfig>
{
    private static readonly string _defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "nx-editor");

    public static string StaticPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "nx-editor-static");

    [JsonIgnore]
    public override string Name { get; } = Path.Combine("nx-editor-static", "global");

    [ObservableProperty]
    [property: Config(
        Header = "Storage Folder",
        Description = """
        The folder where NX-Editor will store plugins, resources, logs, and other internal files

        Warning: The old folder must be deleted manually after closing NX-Editor
        """,
        Group = "Application")]
    [property: BrowserConfig(
        BrowserMode = BrowserMode.OpenFolder,
        Title = "Open Storage Folder",
        InstanceBrowserKey = "global-config-open-storage-folder")]
    private string _storageFolder = _defaultPath;

    partial void OnStorageFolderChanging(string? oldValue, string newValue)
    {
        if (newValue != StaticPath) {
            StorageFolder = oldValue ?? _defaultPath;
            return;
        }

        if (!string.IsNullOrEmpty(oldValue) && Directory.Exists(oldValue)) {
            DirectoryExtension.Copy(oldValue, newValue);
        }
    }
}
