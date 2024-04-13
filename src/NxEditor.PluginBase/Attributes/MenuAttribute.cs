using System.Diagnostics.CodeAnalysis;

namespace NxEditor.PluginBase.Attributes;

[AttributeUsage(AttributeTargets.Method)]
[method: SetsRequiredMembers]
public class MenuAttribute(string name, string path, string? hotkey = null, string? icon = null) : Attribute
{
    public required string Name { get; set; } = name;
    public required string Path { get; set; } = path;
    public string HotKey { get; set; } = hotkey ?? string.Empty;
    public string? Icon { get; set; } = icon;
    public bool IsSeparator { get; set; } = false;
    public string? GetCollectionMethodName { get; set; }
}