﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace NxEditor.PluginBase;

public partial class StatusModal : ObservableObject
{
    public static StatusModal Shared { get; } = new();

    private readonly Timer _timer;

    public StatusModal()
    {
        _timer = new((e) => {
            if (IsWorking) {
                Status = Status.Replace(".....", string.Empty);
                Status += ".";
            }
        });

        _timer.Change(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0.3));
    }

    [ObservableProperty]
    private string _status = "Ready";

    [ObservableProperty]
    private string _icon = "fa-regular fa-message";

    [ObservableProperty]
    private bool _isWorking;

    /// <summary>
    /// Resets the modal status to "Ready"
    /// </summary>
    public static void Reset() => Set("Ready");

    /// <summary>
    /// Sets a custom message and icon to the global status
    /// </summary>
    /// <param name="status">The message to use in the status modal</param>
    /// <param name="icon">The font-awesome icon name and type to use in the status modal</param>
    /// <param name="isWorkingStatus"></param>
    /// <param name="temporaryStatusTime">Reset the status message after a set amount of time (seconds)</param>
    public static void Set(string status, string icon = "fa-regular fa-message", bool? isWorkingStatus = null, double temporaryStatusTime = double.NaN)
    {
        Shared.Status = status;
        Shared.IsWorking = isWorkingStatus ?? status.ToLower() != "ready";
        Shared.Icon = icon;

        if (!double.IsNaN(temporaryStatusTime)) {
            System.Timers.Timer resetTimer = new() {
                AutoReset = false,
                Interval = temporaryStatusTime * 1000.0,
            };

            resetTimer.Elapsed += (s, e) => {
                Reset();
                resetTimer.Dispose();
            };

            resetTimer.Start();
        }
    }
}
