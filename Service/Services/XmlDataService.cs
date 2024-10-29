using Data.Interfaces;
using System.Xml.Serialization;


namespace Service.Services
{
    public class XmlDataService : ISerialization
    {
        public void Serialize<T>(string path, T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, data);
            }

        }

        public T Deserialize<T>(string path)
        {
            var deserializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (T)deserializer.Deserialize(stream);
            }
        }
    }
}
