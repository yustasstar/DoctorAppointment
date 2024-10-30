using Data.Interfaces;
using Data.Repositories;
using Domain.Entities;
using Domain.Enums;
using Service.Interfaces;
using Service.Services;
using System.Text;

namespace UI
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        private readonly DoctorRepository _doctorRepository;

        public DoctorAppointment(string appsettings, ISerialization serialization)
        {
            _doctorService = new DoctorService(appsettings, serialization);
            _patientService = new PatientService(appsettings, serialization);
            _appointmentService = new AppointmentService(appsettings, serialization);
            _doctorRepository = new DoctorRepository(appsettings, serialization);
        }

        public static DataSourceType GetSourceType()
        {
            Console.WriteLine("Select Data source format:");
            Console.WriteLine("Enter number '1' - for JSON data format");
            Console.WriteLine("Enter number '2' - for XML");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int dataFormat) && Enum.IsDefined(typeof(DataSourceType), dataFormat))
                {
                    return (DataSourceType)dataFormat;
                }

                Console.WriteLine("Incorrect data source type. Please enter a valid number!");
            }
        }


        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nSelect an entity to work with:");
                Console.WriteLine("1 - Doctor");
                Console.WriteLine("2 - Patient");
                Console.WriteLine("3 - Appointment");
                Console.WriteLine("0 - Exit");

                var entityChoice = Console.ReadLine();

                switch (entityChoice)
                {
                    case "1":
                        DoctorMenu();
                        break;
                    //case "2":   //TODO:
                    //    PatientMenu();
                    //    break;
                    //case "3":
                    //    AppointmentMenu();
                    //    break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void DoctorMenu()
        {
            while (true)
            {
                Console.WriteLine("\nDoctor Menu:");
                Console.WriteLine("1 - View All Doctors");
                Console.WriteLine("2 - Add Doctor");
                Console.WriteLine("3 - Update Doctor");
                Console.WriteLine("4 - Delete Doctor");
                Console.WriteLine("5 - View Doctor by ID");
                Console.WriteLine("0 - Back to Main Menu");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllDoctors();
                        break;
                    case "2":
                        AddDoctor();
                        break;
                    case "3":
                        UpdateDoctor();
                        break;
                    case "4":
                        DeleteDoctor();
                        break;
                    case "5":
                        ViewDoctorById();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void ViewAllDoctors()
        {
            var doctors = _doctorService.GetAll();
            if (doctors.Count != 0)
            {
                foreach (var doctor in doctors)
                {
                    var infoBuilder = new StringBuilder();
                    infoBuilder.AppendLine("===== Doctor Information ===========");
                    infoBuilder.AppendLine($"Id:          {doctor.Id}");
                    infoBuilder.AppendLine($"Name:        {doctor.Name ?? "N/A"}");
                    infoBuilder.AppendLine($"Surname:     {doctor.Surname ?? "N/A"}");
                    infoBuilder.AppendLine($"Phone:       {doctor.Phone ?? "N/A"}");
                    infoBuilder.AppendLine($"Email:       {doctor.Email ?? "N/A"}");
                    infoBuilder.AppendLine($"Type:        {doctor.DoctorType}");
                    infoBuilder.AppendLine($"Experience:  {doctor.Experience} years");
                    infoBuilder.AppendLine($"Salary:      {doctor.Salary:C}");
                    infoBuilder.AppendLine("====================================");

                    Console.WriteLine(infoBuilder.ToString());

                }
                return;
            }
            Console.WriteLine("No doctors found.");
        }

        private void AddDoctor()
        {
            Console.WriteLine("Enter Doctor Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter Doctor Surname:");
            var surname = Console.ReadLine();

            Console.WriteLine("Enter Doctor Experience (years):");
            if (!byte.TryParse(Console.ReadLine(), out byte experience))
            {
                Console.WriteLine("Invalid experience input. Operation canceled.");
                return;
            }

            var doctorType = GetDoctorType();

            DoctorTypes GetDoctorType()
            {
                Console.WriteLine("Select Doctor Type (1 - Dentist, 2 - Dermatologist, 3 - FamilyDoctor, 4 - Paramedic):");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int doctorType) && Enum.IsDefined(typeof(DoctorTypes), doctorType))
                    {
                        return (DoctorTypes)doctorType;
                    }

                    Console.WriteLine("Incorrect data source type. Please enter a valid number!");
                }
            }

            Console.WriteLine("Enter Salary:");
            if (!decimal.TryParse(Console.ReadLine(), out var salary))
            {
                Console.WriteLine("Invalid salary input. Operation canceled.");
                return;
            }

            var newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Experience = experience,
                DoctorType = doctorType,
                Salary = salary
            };

            _doctorService.Create(newDoctor);
            Console.WriteLine("Doctor added successfully.");
        }

        private void UpdateDoctor()
        {
            Console.WriteLine("Enter Doctor ID to update:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Operation canceled.");
                return;
            }

            var doctor = _doctorService.Get(id);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.WriteLine("Enter new Doctor Name (leave blank to keep current):");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) doctor.Name = name;

            Console.WriteLine("Enter new Doctor Surname (leave blank to keep current):");
            var surname = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(surname)) doctor.Surname = surname;

            Console.WriteLine("Enter new Experience (leave blank to keep current):");
            var expInput = Console.ReadLine();
            if (byte.TryParse(expInput, out byte experience)) doctor.Experience = experience;

            Console.WriteLine("Select new Doctor Type (leave blank to keep current):");
            var typeInput = Console.ReadLine();
            if (Enum.TryParse<DoctorTypes>(typeInput, out var doctorType)) doctor.DoctorType = doctorType;

            Console.WriteLine("Enter new Salary (leave blank to keep current):");
            var salaryInput = Console.ReadLine();
            if (decimal.TryParse(salaryInput, out decimal salary)) doctor.Salary = salary;

            _doctorService.Update(id, doctor);
            Console.WriteLine("Doctor updated successfully.");
        }

        private void DeleteDoctor()
        {
            Console.WriteLine("Enter Doctor ID to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Operation canceled.");
                return;
            }

            if (_doctorService.Delete(id))
            {
                Console.WriteLine("Doctor deleted successfully.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        private void ViewDoctorById()
        {
            Console.WriteLine("Enter Doctor ID:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Operation canceled.");
                return;
            }

            var doctor = _doctorService.Get(id);
            if (doctor != null)
            {
                Console.WriteLine($"ID: {doctor.Id}");
                Console.WriteLine($"Name: {doctor.Name}");
                Console.WriteLine($"Surname: {doctor.Surname}");
                Console.WriteLine($"Experience: {doctor.Experience} years");
                Console.WriteLine($"Type: {doctor.DoctorType}");
                Console.WriteLine($"Salary: {doctor.Salary:C}");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        //Console.WriteLine("Current doctors list: ");
        //var doctors = _doctorService.GetAll();

        //foreach (var doc in doctors)
        //{
        //    Console.WriteLine(doc.Name);
        //}

        //Console.WriteLine("Adding doctor: ");

        //var newDoctor = new Doctor
        //{
        //    Name = "Vasya",
        //    Surname = "Petrov",
        //    Experience = 20,
        //    DoctorType = DoctorTypes.Dentist
        //};

        //_doctorService.Create(newDoctor);

        //Console.WriteLine("Current doctors list: ");
        //doctors = _doctorService.GetAll();

        //foreach (var doc in doctors)
        //{
        //    Console.WriteLine(doc.Name);
        //}

    }

}
