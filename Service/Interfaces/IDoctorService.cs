using Domain.Entities;
using Service.ViewModels;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor Create(Doctor doctor);
        List<DoctorModel> GetAll();
        Doctor? Get(int id);
        bool Delete(int id);
        Doctor Update(int id, Doctor doctor);
    }
}
