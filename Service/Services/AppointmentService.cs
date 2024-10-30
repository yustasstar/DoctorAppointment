using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Service.Interfaces;
using Service.ViewModels;

namespace Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepository;

        public AppointmentService(string appSettings, ISerialization serialization)
        {
            _appointmentRepository = new AppointmentRepository(appSettings, serialization);
        }


        public List<AppointmentModel> GetAll()
        {
            var appointment = _appointmentRepository.GetAll();
            var appModelList = appointment.Select(x => x.ConvertTo()).ToList();
            return appModelList;
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }
    }
}
