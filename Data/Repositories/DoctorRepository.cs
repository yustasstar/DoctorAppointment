using Data.Configuration;
using Data.Interfaces;
using Domain.Entities;
using System.Text;

namespace Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public DoctorRepository()
        {
            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            var infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("===== Doctor Information =====");
            infoBuilder.AppendLine($"Type:        {doctor.DoctorType}");
            infoBuilder.AppendLine($"Experience:  {doctor.Experience} years");
            infoBuilder.AppendLine($"Salary:      {doctor.Salary:C}");
            infoBuilder.AppendLine($"Name:        {doctor.Name ?? "N/A"}");
            infoBuilder.AppendLine($"Surname:     {doctor.Surname ?? "N/A"}");
            infoBuilder.AppendLine($"Phone:       {doctor.Phone ?? "N/A"}");
            infoBuilder.AppendLine($"Email:       {doctor.Email ?? "N/A"}");
            infoBuilder.AppendLine("=============================");

            Console.WriteLine(infoBuilder.ToString());
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());
        }
    }
}
