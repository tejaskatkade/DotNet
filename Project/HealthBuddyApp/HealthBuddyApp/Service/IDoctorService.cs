using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;

namespace HealthBuddyApp.Service
{
    public interface IDoctorService
    {
        ApiResponse addDoctor(DoctorReqDto doctorReqDto);

        List<DoctorResDto> getDoctorsByHospital(long hospId);

        DoctorResDto getDoctorById(long doctorID);

        List<DoctorResDto> getAllDoctors();

        ApiResponse updateDoctor(long doctorId, DoctorReqDto doctorReqDto);

        ApiResponse inActivateDoctor(long doctorId);

        List<DoctorResDto> getAllActiveDoctors();

        ApiResponse activateDoctor(long doctorId);
    }
}
