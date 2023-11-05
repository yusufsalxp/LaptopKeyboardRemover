using Models;

namespace Services.Contracts
{
    public interface IDriverService
    {
        List<Driver> GetDrivers();
        void UninstallDriver(Driver driver);
    }
}