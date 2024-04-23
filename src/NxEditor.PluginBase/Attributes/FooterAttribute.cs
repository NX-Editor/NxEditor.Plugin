namespace NxEditor.PluginBase.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class FooterAttribute(string icon, string description, bool isSeparator = false) : Attribute
{
    public string Icon { get; set; } = icon;
    public string Description { get; set; } = description;
    public bool IsSeparator { get; set; } = isSeparator;
}
