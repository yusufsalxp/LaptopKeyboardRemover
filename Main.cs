using Services.Contracts;

namespace LaptopKeyboardRemover;

public partial class Main : Form
{
    private readonly NotifyIcon _notifyIcon;
    public Main(IPS2KeyboardService ps2KeyboardService)
    {
        InitializeComponent();

        _notifyIcon = new NotifyIcon
        {
            Icon = SystemIcons.Application,
            ContextMenuStrip = new ContextMenuStrip(),
            Visible = true
        };

        if (ps2KeyboardService.IsPS2KeyboardEnabled())
            AddToolStripMenuItemToNotifyIcon("Disable", (sender, e) => ps2KeyboardService.DisablePS2Keyboard());
        else
            AddToolStripMenuItemToNotifyIcon("Enable", (sender, e) => ps2KeyboardService.EnablePS2Keyboard());


        AddToolStripMenuItemToNotifyIcon("Close", (sender, e) => Application.Exit());
    }

    private void AddToolStripMenuItemToNotifyIcon(string name, Action<object, EventArgs> onClick)
    {
        var toolStripMenuItem = new ToolStripMenuItem(name);
        toolStripMenuItem.Click += new EventHandler(onClick!);
        _notifyIcon.ContextMenuStrip!.Items.Add(toolStripMenuItem);
    }

    protected override void SetVisibleCore(bool value)
    {
        value = false;
        if (!IsHandleCreated) CreateHandle();

        base.SetVisibleCore(value);
    }
}
