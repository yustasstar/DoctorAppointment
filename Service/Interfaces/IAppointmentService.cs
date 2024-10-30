using Domain.Entities;
using Service.ViewModels;

namespace Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Create(Appointment appointment);
        List<AppointmentModel> GetAll();
        Appointment? Get(int id);
        bool Delete(int id);
        Appointment Update(int id, Appointment appoinment);
    }
}
