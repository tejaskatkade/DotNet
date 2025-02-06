using AutoMapper;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using HealthBuddyApp.Repository;
using HealthBuddyApp.Service;

namespace HealthBuddyApp.Service.Implementation
{
    public class HospitalServiceImpl : IHospitalService
    {
        private readonly IMapper mapper;
        private readonly IHospitalRepository hospitalRepo;

        public HospitalServiceImpl(IMapper mapper, IHospitalRepository hospitalRepo)
        {
            this.mapper = mapper;
            this.hospitalRepo = hospitalRepo;

        }
        public string activateHospital(long hospId)
        {
            return hospitalRepo.activateHospital(hospId);
        }

        public string addDoctor(long hospId, long doctorId)
        {
            return hospitalRepo.addDoctor(hospId, doctorId);
        }

        public string addHospital(HospitalReqDto hospitalDto)
        {
            Hospital hospital = mapper.Map<Hospital>(hospitalDto);
            return hospitalRepo.addHospital(hospital);
        }

        public List<HospitalResDto> getActiveHospitals()
        {
            List<Hospital> hospitals = hospitalRepo.getActiveHospitals();
            if (hospitals == null) {
                return new List<HospitalResDto>();
            }
            return hospitals.Select( h => mapper.Map<HospitalResDto>(h)).ToList();
  
        }

        public List<HospitalResDto> getAllHospitals()
        {
            List<Hospital> hospitals = hospitalRepo.getAllHospitals();
            if (hospitals == null)
            {
                return new List<HospitalResDto>();
            }
            return hospitals.Select(h => mapper.Map<HospitalResDto>(h)).ToList();
        }

        public string inActivateHospital(long hospId)
        {
           return hospitalRepo.inActivateHospital(hospId);
        }

        public string removeDoctor(long hospId, long doctorId)
        {
            return hospitalRepo.removeDoctor(hospId, doctorId);
        }

        public string updateHospital(long hospId, HospitalReqDto hospitalDto)
        {
            Hospital hospital = mapper.Map<Hospital>(hospitalDto);
            return hospitalRepo.updateHospital(hospId, hospital);
        }
    }
}
