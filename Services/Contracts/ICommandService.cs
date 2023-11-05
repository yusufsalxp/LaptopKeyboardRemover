//create an interface for the command service
namespace Services.Contracts
{
    public interface ICommandService
    {
        string RunCommand(string command);
    }
}