namespace NxEditor.PluginBase.Extensions;

/// <summary>
/// Defines a configuration (settings) extension
/// </summary>
public interface IConfigExtension : IExtensionModule
{
    public IConfigExtension Load();
    public void Save();
}
