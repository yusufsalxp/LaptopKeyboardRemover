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
            var output = _commandService.RunCommand(CommandConstants.SetPS2KeyboardStartTypeToDisabled);

            if (!output.ToLower().Contains("success"))
                throw new Exception("An error occurred while disabling the PS/2 Keyboard Auto Update.");

            var keyboard = GetPS2KeyboardDriver();

            if (keyboard != null)
                _driverService.UninstallDriver(keyboard);
            else
                throw new Exception("An error occurred while finding the PS/2 Keyboard Driver.");
        }

        public void EnablePS2Keyboard()
        {
            var output = _commandService.RunCommand(CommandConstants.SetPS2KeyboardStartTypeToAuto);

            if (!output.ToLower().Contains("success"))
                throw new Exception("An error occurred while enabling the PS/2 Keyboard Auto Update.");
        }

        public Driver? GetPS2KeyboardDriver()
        {
            var drivers = _driverService.GetDrivers();

            return drivers.FirstOrDefault(x => x.DeviceName.Contains("PS/2 Keyboard"));
        }

        public bool IsPS2KeyboardEnabled()
        {
            var driver = GetPS2KeyboardDriver();

            if (driver == null)
                return false;

            var output = _commandService.RunCommand(string.Format(CommandConstants.GetPS2KeyboardStatus, driver.DeviceName));

            return output.Contains("OK");
        }
    }
}