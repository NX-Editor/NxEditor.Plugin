using NxEditor.PluginBase.Attributes;
using System.Reflection;

namespace NxEditor.PluginBase.Services;

public interface IActionService
{
    public CommandAttribute Attribute { get; }
    public MethodInfo Method { get; }
    public Task Execute(Dictionary<string, object> args);
}
