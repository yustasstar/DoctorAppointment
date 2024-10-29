namespace Data.Interfaces
{
    public interface ISerialization
    {
        void Serialize<T>(string path, T data);
        T Deserialize<T>(string path);
    }
}
