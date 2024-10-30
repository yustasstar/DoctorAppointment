using Data.Interfaces;
using Domain.Entities;
using System.Text;

namespace Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepo
    {
        private readonly ISerialization Serialization;
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository(string appSettings, ISerialization serialization) : base(appSettings, serialization)
        {
            Serialization = serialization;
            var result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            var infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("===== Patient Information ====== ");
            infoBuilder.AppendLine($"Name:              {patient.Name ?? "N/A"}");
            infoBuilder.AppendLine($"Surname:           {patient.Surname ?? "N/A"}");
            infoBuilder.AppendLine($"Phone:             {patient.Phone ?? "N/A"}");
            infoBuilder.AppendLine($"Email:             {patient.Email ?? "N/A"}");
            infoBuilder.AppendLine($"IllnessType:       {patient.IllnessType}");
            infoBuilder.AppendLine($"AdditionalInfo:    {patient.AdditionalInfo}");
            infoBuilder.AppendLine($"AdditionalInfo:    {patient.AdditionalInfo}");
            infoBuilder.AppendLine("==================================");

            Console.WriteLine(infoBuilder.ToString());
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;
            Serialization.Serialize(AppSettings, result);
        }
    }
}
