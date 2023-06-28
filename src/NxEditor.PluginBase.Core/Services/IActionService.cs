using NxEditor.PluginBase.Core.Attributes;
using System.Reflection;

namespace NxEditor.PluginBase.Core.Services;

public interface IActionService
{
    public CommandAttribute Attribute { get; }
    public MethodInfo Method { get; }
    public Task Execute(Dictionary<string, object> args);
}
