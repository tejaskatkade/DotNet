using AutoMapper;
using HealthBuddyApp.Context;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using HealthBuddyApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyApp.Service.Implementation
{
    public class PatientServiceImpl : IPatientService
    {
        private IMapper mapper;
        private IPatientRepository repository;
        private AppDBContext context;
       
        public PatientServiceImpl(IPatientRepository repository, IMapper mapper, AppDBContext context) {

            this.repository = repository;
            this.mapper = mapper;
            this.context = context;
        }
        public string activatePatient(long patientId)
        {
            return repository.activatePatient(patientId);
        }

        public string addPatient(PatientReqDto patientDto)
        {
            User user = new User();
            user.UserName = patientDto.Email;
            user.Password = patientDto.Password;
            user.Role = UserRole.ROLE_PATIENT;
            user.IsActive = true;
            context.Users.Add(user);

            //if (patientDto.Gender.Equals("MALE"))
            //{
            //    patientDto.Gender = Gender.MALE;

            //}
            //else
            //{
            //    patientDto.Gender = Gender.FEMALE;

            //}

            Patient patient = mapper.Map<Patient>(patientDto);

            patient.User = user;
            return repository.addPatient(patient);

        }

        public List<PatientResDto> getAllPatients()
        {
            List<Patient> patients =  repository.getAllPatients();
            return patients.Select(p =>  mapper.Map<PatientResDto>(p)).ToList();

        }

        public PatientResDto getPatientById(long patientId)
        {
            Patient patient =  repository.getPatientById(patientId);
            return mapper.Map<PatientResDto>(patient);
        }

        public string inActivatePatient(long patientId)
        {
            return repository.inActivatePatient(patientId);
        }

        public string updatePatient(long id, PatientReqDto patientDto)
        {
            User user = context.Users.FirstOrDefault(p => p.Id == id);
            if (user == null)
                return "Patient not found";

            /*if (patientDto.Gender.Equals("MALE"))
            {
                patientDto.Gender = Gender.MALE;

            }
            else
            {
                patientDto.Gender = Gender.FEMALE;

            }*/

            Patient patient = mapper.Map<Patient>(patientDto);
            patient.User = user;
            patient.Id = id;
            
            return repository.updatePatient(patient);
        }
    }
}
