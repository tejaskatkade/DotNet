using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.Repository
{
    public interface IPatientRepository
    {
        List<Patient> getAllPatients();

        Patient getPatientById(long patientId);

        string addPatient(Patient patient);
        string updatePatient(Patient patient);

        string inActivatePatient(long patientId);

        string activatePatient(long patientId);
    }
}
