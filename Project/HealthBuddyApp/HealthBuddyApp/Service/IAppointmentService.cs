using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;

namespace HealthBuddyApp.Service
{
    public interface IAppointmentService
    {
        string bookAppointment(AppointmentReqDto appointment);

        List<AppointmentResDto> getAllAppointments();

        List<AppointmentResDto> getAppointmentsByDoctorId(long doctorId);
        List<AppointmentResDto> getAppointmentsByHospitalId(long hospId);

        AppointmentResDto getAppointment(long id);

        String cancleAppointment(long appointId);

        String completeAppointment(long appointId);

        List<AppointmentResDto> getAppointmentsBypatientId(long patientId);
    }
}
