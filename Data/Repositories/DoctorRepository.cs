using Data.Interfaces;
using Domain.Entities;
using System.Text;

namespace Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepo
    {
        private readonly ISerialization Serialization;
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public DoctorRepository(string appSettings, ISerialization serialization) : base (appSettings, serialization) 
        {
            Serialization = serialization;
            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor source)
        {
            Console.WriteLine();
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;
            Serialization.Serialize(AppSettings, result);
        }
    }
}
