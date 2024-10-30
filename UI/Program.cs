using Data.Configuration;
using Domain.Enums;
using Service.Services;

namespace UI
{
    public static class Program
    {
        public static void Main()
        {
            var dataFormat = DoctorAppointment.GetSourceType();
            DoctorAppointment? doctorAppointment = dataFormat switch
            {
                DataSourceType.JSON => new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataService()),
                DataSourceType.XML => new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataService()),
                _ => null,
            };

            doctorAppointment?.Menu();
        }
    }
}