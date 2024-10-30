
namespace Service.ViewModels
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "N/A";
        public string Surname { get; set; } = "N/A";
        public string Phone { get; set; } = "N/A";
        public string Email { get; set; } = "N/A";
        public string DoctorType { get; set; } = "N/A";
        public byte Experience { get; set; }
        public decimal Salary { get; set; }
    }
}
