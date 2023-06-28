using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Models;

public class FileHandle : IFileHandle
{
    public byte[] Data { get; set; }
    public string? Path { get; set; }
    public List<IProcessingService> ProcessServices { get; } = new();

    public FileHandle(byte[] data, string? path = null)
    {
        Data = data;
        Path = path;
    }
}
