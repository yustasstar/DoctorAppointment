using Domain.Entities;
using Domain.Enums;


namespace Service.ViewModels
{
    public static class Mapper
    {
        public static DoctorModel ConvertTo(this Doctor doctor)
        {
            if (doctor is null)
            {
                return null;
            }

            string docType;
            switch (doctor.DoctorType)
            {
                case DoctorTypes.Dentist:
                    docType = "Dentist";
                    break;
                case DoctorTypes.Dermatologist:
                    docType = "Dermatologist";
                    break;
                case DoctorTypes.FamilyDoctor:
                    docType = "FamilyDoctor";
                    break;
                case DoctorTypes.Paramedic:
                    docType = "Paramedic";
                    break;
                default:
                    docType = "Unknown";
                    break;
            }

            return new DoctorModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Phone = doctor.Phone,
                Email = doctor.Email,
                DoctorType = docType,
                Experience = doctor.Experience,
                Salary = doctor.Salary
            };
        }
    }
}

