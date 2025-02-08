using HealthBuddyApp.Entity;

namespace HealthBuddyApp.Repository
{
    public interface IAppointmentRepository

    {
        List<Appointment> findBookedTimeSlotsByDoctorAndDate(long doctorId,DateTime date);

        List<Appointment> findByDoctor(Doctor doctor);
        List<Appointment> findByHospital(Hospital hospital);
        List<Appointment> findByPatient(Patient patient);
    }
}
