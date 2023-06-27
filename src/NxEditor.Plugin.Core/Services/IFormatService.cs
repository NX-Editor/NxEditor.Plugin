using NxEditor.Plugin.Core.Models;

namespace NxEditor.Plugin.Core.Services;

/// <summary>
/// Handles an <see cref="IFileHandle"/> request as a file format specification
/// </summary>
public interface IFormatService
{
    /// <summary>
    /// Public dictionary of the availible <see cref="IActionService"/> handles availible for this <see cref="IFormatService"/>
    /// </summary>
    public Dictionary<string, IActionService> Actions { get; }

    /// <summary>
    /// Stores the source <see cref="IFileHandle"/> as a save reference
    /// </summary>
    public IFileHandle FileHandle { get; }

    /// <summary>
    /// Reads the <paramref name="handle"/> into the <see cref="IFormatService"/>
    /// </summary>
    /// <param name="handle"></param>
    public Task Read(IFileHandle handle);

    /// <summary>
    /// Writes the <see cref="IFormatService"/> payload to an <see cref="IFileHandle"/> and returns the result
    /// </summary>
    /// <returns></returns>
    public Task<IFileHandle> Write();
}
