using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Models;

public interface IFileHandle
{
    public string Name { get; set; }
    public byte[] Data { get; set; }
    public string? Path { get; set; }
    public List<IProcessingService> ProcessServices { get; }
}
