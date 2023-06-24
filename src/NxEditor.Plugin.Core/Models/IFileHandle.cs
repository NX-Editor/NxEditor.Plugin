namespace NxEditor.Plugin.Core.Models;

public interface IFileHandle
{
    public byte[] Data { get; set; }
    public string Path { get; set; }
}
