using Domain.Entities;
using Service.ViewModels;

namespace Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        List<PatientModel> GetAll();
        Patient? Get(int id);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
    }
}
