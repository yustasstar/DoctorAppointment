using Data.Interfaces;
using Domain.Entities;
using System.Text;

namespace Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepo
    {
        private readonly ISerialization Serialization;
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository(string appSettings, ISerialization serialization) : base(appSettings, serialization)
        {
            Serialization = serialization;
            var result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            var infoBuilder = new StringBuilder();
            infoBuilder.AppendLine("===== Appointment Information ======");
            infoBuilder.AppendLine($"Patient:    {appointment.Patient}");
            infoBuilder.AppendLine($"Doctor:     {appointment.Doctor}");
            infoBuilder.AppendLine($"Phone:      {appointment.DateTimeFrom}");
            infoBuilder.AppendLine($"Email:      {appointment.DateTimeTo}");
            infoBuilder.AppendLine($"Type:       {appointment.Description}");
            infoBuilder.AppendLine("====================================");

            Console.WriteLine(infoBuilder.ToString());
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;
            Serialization.Serialize(AppSettings, result);
        }
    }
}
