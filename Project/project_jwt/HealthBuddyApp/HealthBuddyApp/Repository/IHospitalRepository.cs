using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;

namespace HealthBuddyApp.Repository
{
    public interface IHospitalRepository
    {
        List<Hospital> getAllHospitals();

        string addHospital(Hospital hospital);

        String addDoctor(long hospId, long doctorId);

        String activateHospital(long hospId);
        String inActivateHospital(long hospId);

        String removeDoctor(long hospId, long doctorId);
        List<Hospital> getActiveHospitals();
        string updateHospital(long hospId, Hospital hospital);

    }
}
