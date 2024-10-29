using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Service.Interfaces;
using Service.ViewModels;

namespace Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepository;

        public DoctorService(string appSettings, ISerialization serialization)
        {
            _doctorRepository = new DoctorRepository(appSettings, serialization);
        }

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public List<DoctorModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorModels = doctors.Select(x => x.ConvertTo()).ToList();
            return doctorModels;
        }

        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }
    }
}
