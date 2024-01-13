
using NxEditor.PluginBase.Services;
using System.Collections.ObjectModel;

namespace NxEditor.PluginBase.Models;

public sealed class EditorFile(string id, string name, ReadEditorFile read, WriteEditorFile write) : IEditorFile
{
    public string Id { get; } = id;
    public string Name { get; set; } = name;
    public ReadEditorFile Read { get; set; } = read;
    public WriteEditorFile Write { get; set; } = write;
    public ObservableCollection<IProcessingService> Services { get; } = [];

    /// <summary>
    /// Create a new <see cref="IEditorFile"/> from a local file.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static EditorFile FromFile(string file)
    {
        return new(
            file,
            Path.GetFileName(file),
            (editor) => ReadFromDisk(editor.Id),
            (editor, data) => WriteToDisk(editor.Id, data)
        );
    }

    /// <summary>
    /// Reads from disk assuming <see cref="Id"/> is the file path.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Span<byte> ReadFromDisk(string file)
    {
        if (!File.Exists(file)) {
            throw new FileNotFoundException($"""
                Error reading EditorFile from disk, the file '{file}' could not be found.
                """);
        }

        return File.ReadAllBytes(file);
    }

    /// <summary>
    /// Writes to disk assuming <see cref="Id"/> is the file path.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static void WriteToDisk(string file, Span<byte> data)
    {
        if (Path.GetDirectoryName(file) is string folder) {
            Directory.CreateDirectory(folder);
        }

        using FileStream fs = File.Create(file);
        fs.Write(data);
    }
}
