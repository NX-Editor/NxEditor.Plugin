namespace NxEditor.PluginBase.Components;

public record SearchContext(string FindArgument, string? ReplaceArgument, bool IsCaseSensitive, bool IsReplacing)
{
    public StringComparison StringComparison { get; } = IsCaseSensitive switch {
        true => StringComparison.InvariantCulture,
        false => StringComparison.InvariantCultureIgnoreCase,
    };
}
