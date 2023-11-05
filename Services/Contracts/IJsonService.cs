namespace Services.Contracts
{
    public interface IJsonService
    {
        T? Deserialize<T>(string json);
        string Serialize<T>(T obj);
    }
}