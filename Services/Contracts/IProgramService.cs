namespace Services.Contracts
{
    public interface IProgramService
    {
        void SetStartup(bool enable);

        bool IsStartupEnabled();
    }
}