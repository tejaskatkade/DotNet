using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.Service
{
    public interface IHospitalService
    {
        List<HospitalResDto> getAllHospitals();

        string addHospital(HospitalReqDto hospital);

        string addDoctor(long hospId, long doctorId);

        string activateHospital(long hospId);
        string inActivateHospital(long hospId);

        string removeDoctor(long hospId, long doctorId);
        List<HospitalResDto> getActiveHospitals();
        string updateHospital(long hospId, HospitalReqDto hospital);
    }
}
