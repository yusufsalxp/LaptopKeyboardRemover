using System.Diagnostics;
using Services.Contracts;

namespace LaptopKeyboardRemover;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();

        var commandService = ContainerService.Resolve<ICommandService>();
        var output = commandService.RunCommand("dir");

        var label = new Label
        {
            Text = output,
            AutoSize = true,
            Location = new Point(10, 10),
        };

        Controls.Add(label);
    }
}
