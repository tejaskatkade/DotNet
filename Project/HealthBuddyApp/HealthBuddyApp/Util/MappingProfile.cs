using AutoMapper;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.Util
{
    public class MappingProfile : Profile
    {
     
           public MappingProfile()
            {
                CreateMap<DoctorReqDto, Doctor>();
                CreateMap<Doctor, DoctorResDto>();

                CreateMap<Hospital,HospitalResDto>();
                CreateMap<HospitalReqDto,Hospital>();

                CreateMap<PatientReqDto,Patient>();
                CreateMap<Patient,PatientResDto>();

                CreateMap<Appointment,AppointmentResDto>();
                CreateMap<AppointmentReqDto,Appointment>();        
                
        }
        
    }
}
