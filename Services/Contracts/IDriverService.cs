using Models;

namespace Services.Contracts
{
    public interface IDriverService
    {
        List<Driver> GetDrivers();
        Driver? GetPS2KeyboardDriver();
        void UninstallDriver(Driver driver);
    }
}