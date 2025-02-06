using AutoMapper;
using HealthBuddyApp.Context;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using HealthBuddyApp.Repository;

namespace HealthBuddyApp.Service.Implementation
{
    public class DoctorServiceImpl : IDoctorService
    {
        private IMapper _mapper;
        private IDoctorRepository _repository;
        private AppDBContext context;
        public DoctorServiceImpl(IDoctorRepository repository, IMapper mapper, AppDBContext context)
        {
                _repository = repository;
                _mapper = mapper;
            this.context = context;
        }
        /*public DoctorServiceImpl()
        {
        }*/
        public ApiResponse activateDoctor(long doctorId)
        {
            return new ApiResponse(_repository.activateDoctor(doctorId));
        }

        public ApiResponse addDoctor(DoctorReqDto doctorReqDto)
        {
            User user = new User();
            user.UserName = doctorReqDto.Email;
            user.Password = doctorReqDto.Password;
            user.Role = UserRole.ROLE_DOCTOR;
            user.IsActive = true;


            context.Users.Add(user);
            context.SaveChanges();
            var persistentUser = context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (persistentUser == null)
            {
                return new ApiResponse("Failed to retrieve persistent User after saving.");
            }

            // Map DoctorReqDto to Doctor
            Doctor doctor = _mapper.Map<Doctor>(doctorReqDto);
            
            // Assign the persistent User reference to the Doctor
            doctor.User = persistentUser; // Assign the User entity
            doctor.User.Id = persistentUser.Id; // Assign foreign key

            // Save the Doctor entity
            //_repository.AddDoctor(doctor);
            return new ApiResponse(_repository.addDoctor(doctor));
        }

        public List<DoctorResDto> getAllActiveDoctors()
        {
            // return _repository.getAllActiveDoctors().Select(doctor => _mapper.Map<DoctorResDto>(doctor)).ToList();
            var activeDoctors = _repository.getAllActiveDoctors();
            if (activeDoctors == null) 
                return new List<DoctorResDto>();

            return activeDoctors
                .Select(doctor => _mapper.Map<DoctorResDto>(doctor))
                .ToList();

        }

        public List<DoctorResDto> getAllDoctors()
        {
            List<Doctor> doctors = _repository.getAllDoctors();
             
                if(doctors != null)
                   return doctors.Select(doctor => _mapper.Map<DoctorResDto>(doctor)).ToList();
            return new List<DoctorResDto>();
        }

        public DoctorResDto getDoctorById(long doctorID)
        {
            Doctor doctor =  _repository.getDoctorById(doctorID);
                return _mapper.Map<DoctorResDto>(doctor);
            
        }

        public List<DoctorResDto> getDoctorsByHospital(long hospId)
        {
            return _repository.getDoctorsByHospital(hospId).Select(doctor => _mapper.Map<DoctorResDto>(doctor)).ToList();
        }

        public ApiResponse inActivateDoctor(long doctorId)
        {
            return new ApiResponse(_repository.inActivateDoctor(doctorId));
        }

        public ApiResponse updateDoctor(long doctorId, DoctorReqDto doctorReqDto)
        {
            Doctor newDoctor = _mapper.Map<Doctor>(doctorReqDto);
            Doctor doctor = _repository.getDoctorById(doctorId);
            newDoctor.User = context.Users.FirstOrDefault(i => i.Id == doctor.User.Id);
            return new ApiResponse(_repository.updateDoctor(doctorId, newDoctor));
        }
    }
}
