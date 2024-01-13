using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Models;

public interface IFileHandle
{
    public string Name { get; set; }
    public byte[] Data { get; set; }
    public string? FilePath { get; set; }
    public string Id { get; }
    public List<IProcessingService> ProcessServices { get; }
}
