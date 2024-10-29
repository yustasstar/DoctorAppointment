using Domain.Entities;
using Microsoft.Exchange.WebServices.Data;

namespace Data.Interfaces
{
    public interface IAppointmentRepo
    {   
        Appointment GetAllByDoctor(Doctor doctor);
        Appointment GetAllByPatient(Patient patient);
    }
}
