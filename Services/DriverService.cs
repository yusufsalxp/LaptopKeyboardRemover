using System.Management;
using AutoMapper;
using LaptopKeyboardRemover;
using Models;
using Newtonsoft.Json;
using Services.Contracts;
using Utils;

namespace Services
{
    public class DriverService : IDriverService
    {
        private ICommandService _commandService;
        public DriverService(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public List<Driver> GetDrivers()
        {
            var drivers = new List<Driver>();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPSignedDriver");

            foreach (var obj in searcher.Get())
                drivers.Add(new Driver()
                {
                    DeviceName = obj["DeviceName"]?.ToString() ?? "",
                    DeviceId = obj["DeviceID"]?.ToString() ?? "",
                    DriverName = obj["DriverName"]?.ToString() ?? "",
                    DriverProviderName = obj["DriverProviderName"]?.ToString() ?? "",
                    DriverVersion = obj["DriverVersion"]?.ToString() ?? "",
                    InfName = obj["InfName"]?.ToString() ?? ""
                });



            return drivers;
        }

        public void UninstallDriver(Driver driver)
        {
            var output = _commandService.RunCommand($"pnputil /remove-device {driver.DeviceId}");

            if (output.ToLower().Contains("error"))
                throw new Exception("Error uninstalling driver");

        }
    }

}