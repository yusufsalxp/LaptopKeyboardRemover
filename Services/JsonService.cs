using Newtonsoft.Json;
using Services.Contracts;

namespace Services
{
    public class JsonService : IJsonService
    {
        public T? Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}