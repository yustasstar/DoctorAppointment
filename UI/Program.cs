using Data.Configuration;
using Domain.Enums;
using Service.Services;

namespace UI
{
    public static class Program
    {
        public static void Main()
        {
            DoctorAppointment? doctorAppointment;
            var dataFormat = DoctorAppointment.GetSourceType();

            switch (dataFormat)
            {
                case DataSourceType.JSON:
                    doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataService());
                    break;
                case DataSourceType.XML:
                    doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataService());
                    break;
                default:
                    doctorAppointment = null;
                    break;
            }

            doctorAppointment?.Menu();
        }
    }
}