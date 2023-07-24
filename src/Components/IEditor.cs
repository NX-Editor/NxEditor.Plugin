﻿using Avalonia.Controls;
using NxEditor.PluginBase.Services;

namespace NxEditor.PluginBase.Components;

public interface IEditor : IEditorInterface, IFormatService
{
    public Control View { get; }
    public bool HasChanged { get; }
    public Task Cleanup();
}
