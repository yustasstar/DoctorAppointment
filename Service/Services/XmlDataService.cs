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
            // Check if the file exists, create a new file if it does not
            if (!File.Exists(path))
            {
                // Create an empty XML file with a root element to avoid "Root element is missing" error
                var serializer = new XmlSerializer(typeof(T));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(stream, Activator.CreateInstance<T>());
                }
            }

            // Now attempt to deserialize
            var deserializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                try
                {
                    return (T)deserializer.Deserialize(stream);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException($"Failed to deserialize XML file: {path}. Ensure the file has a valid XML structure.", ex);
                }
            }
        }
    }
}
