using NxEditor.PluginBase.Core.Services;

namespace NxEditor.PluginBase.Core.Models;

public interface IFileHandle
{
    public byte[] Data { get; set; }
    public string? Path { get; set; }
    public List<IProcessingService> ProcessServices { get; }
}
