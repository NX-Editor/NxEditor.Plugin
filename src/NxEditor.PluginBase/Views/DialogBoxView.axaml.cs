using Avalonia.Controls;
using NxEditor.PluginBase.Common;

namespace NxEditor.PluginBase.Views;

public partial class DialogBoxView : UserControl
{
    public DialogBoxView() { }
    public DialogBoxView(DialogBox content)
    {
        InitializeComponent();
        DataContext = content;
    }
}