using Data.Interfaces;
using Newtonsoft.Json;

namespace Service.Services
{
    public class JsonDataService : ISerialization
    {
        public void Serialize<T>(string path, T data)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public T Deserialize<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
