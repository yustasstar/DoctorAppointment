using Domain.Entities;
using Domain.Enums;
using Service.Interfaces;
using Service.Services;

namespace UI
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
        }

        public void Menu()
        {
            var dataType = new DataSourceType();

            switch (dataType)
            {
                case DataSourceType.JSON:
                    break;
                case DataSourceType.XML:
                    break;
                default:
                    break;
            }
            //while (true)
            //{
            //    // add Enum for menu items and describe menu
            //    break;
            //}

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
                DoctorType = Domain.Enums.DoctorTypes.Dentist
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
