namespace NxEditor.PluginBase.Core.Extensions;

/// <summary>
/// Defines a configuration (settings) extension
/// </summary>
public interface IConfigExtension : IExtensionModule
{
    public IConfigExtension Load();
    public void Save();
}
