using Domain.Entities;
using Domain.Enums;
using Microsoft.Exchange.WebServices.Data;


namespace Service.ViewModels
{
    public static class Mapper
    {
        public static DoctorModel? ConvertTo(this Doctor doctor)
        {
            if (doctor is null)
            {
                return null;
            }

            string docType = doctor.DoctorType switch
            {
                DoctorTypes.Dentist => "Dentist",
                DoctorTypes.Dermatologist => "Dermatologist",
                DoctorTypes.FamilyDoctor => "FamilyDoctor",
                DoctorTypes.Paramedic => "Paramedic",
                _ => "Unknown",
            };

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

        public static PatientModel? ConvertTo(this Patient patient)
        {
            if (patient is null) { return null; }


            string illnessType = patient.IllnessType switch
            {
                IllnessTypes.EyeDisease => "EyeDisease",
                IllnessTypes.Infection => "Infection",
                IllnessTypes.DentalDisease => "DentalDisease",
                IllnessTypes.SkinDisease => "SkinDisease",
                IllnessTypes.Ambulance => "Ambulance",
                _ => "Unknown",
            };


            return new PatientModel()
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Phone = patient.Phone,
                Email = patient.Email,
                IllnessType = illnessType,
                Address = patient.Address,
                AdditionalInfo = patient.AdditionalInfo
            };
        }

        public static AppointmentModel? ConvertTo(this Domain.Entities.Appointment appointment)
        {
            if (appointment is null)
            {
                return null;
            }

            return new AppointmentModel()
            {
                Patient = appointment.Patient,
                Doctor = appointment.Doctor,
                DateTimeFrom = appointment.DateTimeFrom,
                DateTimeTo = appointment.DateTimeTo,
                Description = appointment.Description
            };
        }

    }
}

