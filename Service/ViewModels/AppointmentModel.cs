using Domain.Entities;

namespace Service.ViewModels
{
    public class AppointmentModel
    {
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Description { get; set; } = "N/A";
    }
}
