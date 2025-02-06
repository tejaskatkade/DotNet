using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;

namespace HealthBuddyApp.Service
{
    public interface IPatientService
    {
        List<PatientResDto> getAllPatients();

        PatientResDto getPatientById(long patientId);

        String addPatient(PatientReqDto patientDto);
        String updatePatient(long id, PatientReqDto patientDto);

        String inActivatePatient(long patientId);

        String activatePatient(long patientId);
    }
}
