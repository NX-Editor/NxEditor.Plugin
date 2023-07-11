namespace NxEditor.PluginBase;

/// <summary>
/// Public extension interface
/// </summary>
public interface IServiceExtension
{
    public IServiceExtension Shared { get; }
    public string Name { get; }
    public void RegisterExtension(IServiceLoader serviceManager);
}
