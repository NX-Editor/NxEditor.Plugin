namespace NxEditor.PluginBase.Component;

public static class EditorConfig
{
    public static string CacheFolder { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "nx-editor", "cache");
}
