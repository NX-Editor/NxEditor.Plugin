using NxEditor.Plugin.Core.Attributes;
using System.Reflection;

namespace NxEditor.Plugin.Core.Services;

public interface IActionService
{
    public CommandAttribute Attribute { get; }
    public MethodInfo Method { get; }
    public Task Execute(Dictionary<string, object> args);
}
