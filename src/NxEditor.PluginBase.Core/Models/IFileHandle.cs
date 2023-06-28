using NxEditor.Plugin.Core.Services;

namespace NxEditor.Plugin.Core.Models;

public interface IFileHandle
{
    public byte[] Data { get; set; }
    public string? Path { get; set; }
    public List<IProcessingService> ProcessServices { get; }
}
