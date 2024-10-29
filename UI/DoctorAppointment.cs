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

        public DoctorAppointment(string appsettings, ISerialization serialization)
        {
            _doctorService = new DoctorService(appsettings, serialization);
        }

        public void Menu()
        {
            Console.WriteLine("Current doctors list: ");
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
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
            docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }
        }
    }

}
