using Data.Configuration;
using Data.Interfaces;
using Service.Services;

namespace UI
{
    public static class Program
    {
        public static void Main()
        {
            DoctorAppointment? doctorAppointment = null;

            Console.WriteLine("Select Data sourse format:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");
            var dataFormat = Console.ReadLine();

            switch (dataFormat)
            {
                case "1":
                    doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataService());
                    break;
                case "2":
                    doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataService());
                    break;
                default:
                    Console.WriteLine("Inccorect Data sourse type. Please enter correct value!");
                    dataFormat = Console.ReadLine();
                    break;
            }

            doctorAppointment.Menu();
        }
    }
}