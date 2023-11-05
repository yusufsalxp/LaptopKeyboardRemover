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
        private IMapperService _mapperService;
        public DriverService(
            ICommandService commandService,
            IMapperService mapperService
        )
        {
            _commandService = commandService;
            _mapperService = mapperService;
        }

        public List<Driver> GetDrivers()
        {
            var drivers = new List<Driver>();
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPSignedDriver");

            foreach (var obj in searcher.Get())
            {

                drivers.Add(new Driver()
                {
                    DeviceName = obj["DeviceName"]?.ToString() ?? "",
                    DeviceId = obj["DeviceID"]?.ToString() ?? "",
                    DriverName = obj["DriverName"]?.ToString() ?? "",
                    DriverProviderName = obj["DriverProviderName"]?.ToString() ?? "",
                    DriverVersion = obj["DriverVersion"]?.ToString() ?? "",
                    InfName = obj["InfName"]?.ToString() ?? "",
                });

            }

            return drivers;
        }

        public Driver? GetPS2KeyboardDriver()
        {
            var drivers = GetDrivers();

            return drivers.FirstOrDefault(x => x.DeviceName.Contains("PS/2 Keyboard"));
        }

        public void UninstallDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }

}