using Models;

namespace Services.Contracts
{
    public interface IPS2KeyboardService
    {
        void DisablePS2Keyboard();
        void EnablePS2Keyboard();
        bool IsPS2KeyboardEnabled();
        Driver? GetPS2KeyboardDriver();
    }
}