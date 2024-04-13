using ConfigFactory.Core.Models;
using ConfigFactory.Models;

namespace NxEditor.PluginBase.Extensions;

public static class ConfigExtension
{
    public static void SetValue(this ConfigPageModel configPage, string configName, string propertyName, object? value)
    {
        if (configPage.ConfigModules.TryGetValue(configName, out var module) &&
            module.Shared.Properties.TryGetValue(propertyName, out ConfigProperty? property)) {
            property.Property.SetValue(module, value);
        }
    }

    public static T? GetValue<T>(this ConfigPageModel configPage, string configName, string propertyName)
    {
        if (configPage.ConfigModules.TryGetValue(configName, out var module) &&
            module.Shared.Properties.TryGetValue(propertyName, out ConfigProperty? property)) {
            return (T?)property.Property.GetValue(module);
        }

        return default;
    }
}
