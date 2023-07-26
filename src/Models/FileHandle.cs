using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Models;

public class FileHandle : IFileHandle
{
    public string Name { get; set; } = string.Empty;
    public byte[] Data { get; set; }
    public string? Path { get; set; }
    public List<IProcessingService> ProcessServices { get; } = new();

    public FileHandle(byte[] data, string? path = null)
    {
        Name = path is not null ? System.IO.Path.GetFileName(path)
            : string.Empty;
        Data = data;
        Path = path;
    }

    public FileHandle(string path)
    {
        Name = System.IO.Path.GetFileName(path);
        Data = File.ReadAllBytes(path);
        Path = path;
    }
}
