using HealthBuddyApp.Context;
using HealthBuddyApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyApp.Repository.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private AppDBContext _context;
        public AppointmentRepository(AppDBContext context) {
            _context = context;
        }
        public List<Appointment> findBookedTimeSlotsByDoctorAndDate(long doctorId, DateTime date)
        {
            return _context.Appointments
            .Include(a => a.Doctor)
            .Where(a => a.Doctor.Id == doctorId && a.AppointementDate.Date == date.Date && a.Status != AppointmentStatus.CANCELLED)
            .ToList();
        }

        public List<Appointment> findByDoctor(Doctor doctor)
        {
            return _context.Appointments
            .Include(a => a.Doctor)
            .Where(a => a.Doctor.Id == doctor.Id)
            .ToList();
        }

        public List<Appointment> findByHospital(Hospital hospital)
        {
            return _context.Appointments
            .Include(a => a.Hospital)
            .Where(a => a.Hospital.Id == hospital.Id)
            .ToList();
        }

        public List<Appointment> findByPatient(Patient patient)
        {
            return _context.Appointments
            .Include(a => a.Patient)
            .Where(a => a.Patient.Id == patient.Id)
            .ToList();
        }
    }
}
