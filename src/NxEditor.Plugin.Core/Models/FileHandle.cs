using NxEditor.Plugin.Models;

namespace NxEditor.Plugin.Core.Models;

public class FileHandle : IFileHandle
{
    public byte[] Data { get; set; }
    public string Path { get; set; }

    public FileHandle(byte[] data, string path)
    {
        Data = data;
        Path = path;
    }
}
