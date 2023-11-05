using Services.Contracts;

namespace LaptopKeyboardRemover;

public partial class Main : Form
{
    private readonly IPS2KeyboardService _ps2KeyboardService;
    public Main(IPS2KeyboardService ps2KeyboardService)
    {
        InitializeComponent();
        _ps2KeyboardService = ps2KeyboardService;

        _ps2KeyboardService.DisablePS2Keyboard();

        var label = new Label
        {
            Text = _ps2KeyboardService.GetPS2KeyboardDriver()?.DeviceName ?? "No PS/2 Keyboard driver found",
            AutoSize = true,
            Location = new Point(10, 10),
        };

        Controls.Add(label);
    }
}
