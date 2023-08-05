using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using NxEditor.PluginBase.Views;

namespace NxEditor.PluginBase.Common;

public enum DialogResult
{
    None, Primary, Secondary
}

public enum DialogDefaultButton
{
    None, Primary, Secondary
}

public partial class DialogBox : ObservableObject
{
    private static Panel? _root;

    private bool _isDialogWaiting = true;
    private DialogResult _result = DialogResult.Primary;
    private readonly DialogBoxView _dialog;

    public static void SetViewRoot(Panel root)
    {
        _root = root;
    }

    public DialogBox()
    {
        _dialog = new(this);
    }

    [ObservableProperty]
    private object? _content;

    [ObservableProperty]
    private string? _title;

    [ObservableProperty]
    private object _primaryButtonContent = "Ok";

    [ObservableProperty]
    private bool _isPrimaryButtonVisible = true;

    [ObservableProperty]
    private Func<RoutedEventArgs, Task>? _primaryButtonAction;

    [ObservableProperty]
    private object _secondaryButtonContent = "Cancel";

    [ObservableProperty]
    private bool _isSecondaryButtonVisible = true;

    [ObservableProperty]
    private Func<RoutedEventArgs, Task>? _secondaryButtonAction;

    public async Task PrimaryButtonCommand()
    {
        RoutedEventArgs args = new();
        if (SecondaryButtonAction?.Invoke(args) is Task task) {
            await task;
        }

        _result = DialogResult.Primary;
        if (!args.Handled) {
            Close();
        }
    }

    public async Task SecondaryButtonCommand()
    {
        RoutedEventArgs args = new();
        if (SecondaryButtonAction?.Invoke(args) is Task task) {
            await task;
        }

        _result = DialogResult.Secondary;
        if (!args.Handled) {
            Close();
        }
    }

    public void Close()
    {
        _root?.Children.Remove(_dialog);
        _isDialogWaiting = false;
    }

    public static async Task<DialogResult> ShowAsync(string? title, object? content) => await ShowAsync(title, content, showPrimaryButton: true);
    public static async Task<DialogResult> ShowAsync(string? title, object? content,
        bool showPrimaryButton = true, object? primaryButtonContent = null, Func<RoutedEventArgs, Task>? primaryButtonAction = null,
        bool showSecondaryButton = true, object ? secondaryButtonContent = null, Func<RoutedEventArgs, Task>? secondaryButtonAction = null)
    {
        return await new DialogBox() {
            Title = title,
            Content = new ContentControl {
                Content = content
            },
            IsPrimaryButtonVisible = showPrimaryButton,
            PrimaryButtonContent = primaryButtonContent ?? "Ok",
            PrimaryButtonAction = primaryButtonAction,
            IsSecondaryButtonVisible = showSecondaryButton,
            SecondaryButtonContent = secondaryButtonContent ?? "Cancel",
            SecondaryButtonAction = secondaryButtonAction,
        }.ShowAsync();
    }

    public async Task<DialogResult> ShowAsync()
    {
        _root?.Children.Add(_dialog);
        _dialog.PrimaryButton.Focus();
        await Task.Run(() => {
            while (_isDialogWaiting) { }
        });

        return _result;
    }
}
