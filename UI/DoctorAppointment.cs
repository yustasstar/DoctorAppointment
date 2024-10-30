using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Service.Interfaces;
using Service.Services;

namespace UI
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DoctorAppointment(string appsettings, ISerialization serialization)
        {
            _doctorService = new DoctorService(appsettings, serialization);
        }

        public static DataSourceType GetSourceType()
        {
            Console.WriteLine("Select Data source format:");
            Console.WriteLine("Enter number '1' - for JSON data format");
            Console.WriteLine("Enter number '2' - for XML");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int dataFormat) && Enum.IsDefined(typeof(DataSourceType), dataFormat))
                {
                    return (DataSourceType)dataFormat;
                }

                Console.WriteLine("Incorrect data source type. Please enter a valid number!");
            }
        }


        public void Menu()
        {
            Console.WriteLine("Current doctors list: ");
            var doctors = _doctorService.GetAll();

            foreach (var doc in doctors)
            {
                Console.WriteLine(doc.Name);
            }

            Console.WriteLine("Adding doctor: ");

            var newDoctor = new Doctor
            {
                Name = "Vasya",
                Surname = "Petrov",
                Experience = 20,
                DoctorType = DoctorTypes.Dentist
            };

            _doctorService.Create(newDoctor);

            Console.WriteLine("Current doctors list: ");
            doctors = _doctorService.GetAll();

            foreach (var doc in doctors)
            {
                Console.WriteLine(doc.Name);
            }
        }
    }

}
