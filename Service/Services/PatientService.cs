using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Service.Interfaces;
using Service.ViewModels;

namespace Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepository;

        public PatientService(string appSettings, ISerialization serialization)
        {
            _patientRepository = new PatientRepository(appSettings, serialization);
        }


        public List<PatientModel> GetAll()
        {
            var patients = _patientRepository.GetAll();
            var patientModelList = patients.Select(x => x.ConvertTo()).ToList();
            return patientModelList;
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
    }
}
