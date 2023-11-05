using Models;
using Services.Contracts;

namespace Services
{
    public class PS2KeyboardService : IPS2KeyboardService
    {
        private readonly IDriverService _driverService;
        private readonly ICommandService _commandService;

        public PS2KeyboardService(
            IDriverService driverService,
            ICommandService commandService
        )
        {
            _driverService = driverService;
            _commandService = commandService;
        }

        public void DisablePS2Keyboard()
        {
            var output = _commandService.RunCommand("sc config i8042prt start= disabled");
            var keyboard = GetPS2KeyboardDriver();

            if (keyboard != null)
                _driverService.UninstallDriver(keyboard);
        }

        public void EnablePS2Keyboard()
        {
            var output = _commandService.RunCommand("sc config i8042prt start= auto");
        }

        public Driver? GetPS2KeyboardDriver()
        {
            var drivers = _driverService.GetDrivers();

            return drivers.FirstOrDefault(x => x.DeviceName.Contains("PS/2 Keyboard"));
        }

        public bool IsPS2KeyboardEnabled()
        {
            throw new System.NotImplementedException();
        }
    }
}