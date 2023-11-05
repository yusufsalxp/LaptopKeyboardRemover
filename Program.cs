using AutoMapper;
using Models;
using Services.Contracts;

namespace LaptopKeyboardRemover;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ContainerService.Start();
        ApplicationConfiguration.Initialize();
        Application.Run(ContainerService.Resolve<Main>());
    }
}