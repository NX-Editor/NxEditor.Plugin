using NxEditor.PluginBase.Models;

namespace NxEditor.PluginBase.Services;

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
    /// The supported file extensions when writing the <see cref="IFormatProvider"/>
    /// </summary>
    public string[] ExportExtensions { get; }

    /// <summary>
    /// Stores the source <see cref="IFileHandle"/> as a save reference
    /// </summary>
    public IFileHandle Handle { get; }

    /// <summary>
    /// Reads the <see cref="Handle"/>
    /// </summary>
    public Task Read();

    /// <summary>
    /// Writes the <see cref="IFormatService"/> payload to an <see cref="IFileHandle"/> and returns the result
    /// </summary>
    /// <returns></returns>
    public Task<IFileHandle> Write();
}
