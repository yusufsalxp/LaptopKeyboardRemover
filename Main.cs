using Services.Contracts;

namespace LaptopKeyboardRemover;

public partial class Main : Form
{
    public Main(IDriverService driverService)
    {
        InitializeComponent();

        var label = new Label
        {
            Text = driverService.GetPS2KeyboardDriver()?.DeviceName ?? "No PS/2 Keyboard driver found",
            AutoSize = true,
            Location = new Point(10, 10),
        };

        Controls.Add(label);
    }
}
