using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepo<TSource> where TSource : Auditable
    {
        public ISerialization Serialization { get; private set; }
        public string AppSettings {  get; private set; }
        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }

        public GenericRepository(string appsetings, ISerialization serialization)
        {
            Serialization = serialization;
            AppSettings = appsetings;
        }


        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
            var doctors = GetAll().Append(source).ToList();
            //File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Append(source), Formatting.Indented));
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            Serialization.Serialize(Path, GetAll().Where(x => x.Id != id));

            //File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Where(x => x.Id != id), Formatting.Indented));

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            //if (!File.Exists(Path))
            //{
            //    File.WriteAllText(Path, "[]");
            //}

            //var json = File.ReadAllText(Path);

            //if (string.IsNullOrWhiteSpace(json))
            //{
            //    File.WriteAllText(Path, "[]");
            //    json = "[]";
            //}

            return Serialization.Deserialize<IEnumerable<TSource>>(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            //File.WriteAllText(Path, JsonConvert.SerializeObject(GetAll().Select(x => x.Id == id ? source : x), Formatting.Indented));

            Serialization.Serialize(Path, GetAll().Select(x => x.Id == id ? source : x));
            return source;
        }

        public abstract void ShowInfo(TSource source);
        protected abstract void SaveLastId();
        protected Repository ReadFromAppSettings()
        {
            return Serialization.Deserialize<Repository>(AppSettings);
        }
        //protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.JsonAppSettingsPath))!;
    }
}
