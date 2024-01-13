using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Models;

public class FileHandle : IFileHandle
{
    public string Name { get; set; } = string.Empty;
    public byte[] Data { get; set; }
    public string? FilePath { get; set; }
    public string Id { get; }
    public List<IProcessingService> ProcessServices { get; } = [];

    public FileHandle(byte[] data, string name, string id)
    {
        Name = name;
        Data = data;
        Id = id;
    }

    public FileHandle(string path)
    {
        Name = Path.GetFileName(path);
        Data = File.ReadAllBytes(path);
        FilePath = path;
        Id = path;
    }
}
