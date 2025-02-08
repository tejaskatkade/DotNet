
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using System.Collections.Generic;

namespace HealthBuddyApp.Repository
{
    public interface IDoctorRepository
    {
        List<Doctor> findDoctorsByHospitalId(long hosplId);
        string addDoctor(Doctor doctor);

        List<Doctor> getDoctorsByHospital(long hospId);

        Doctor getDoctorById(long doctorID);

        List<Doctor> getAllDoctors();

        string updateDoctor(long doctorId,Doctor doctorReqDto);

        string inActivateDoctor(long doctorId);

        List<Doctor> getAllActiveDoctors();

        string activateDoctor(long doctorId);
    }
}
