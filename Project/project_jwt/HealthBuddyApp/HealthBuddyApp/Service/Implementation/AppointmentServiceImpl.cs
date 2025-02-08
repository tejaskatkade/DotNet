using AutoMapper;
using HealthBuddyApp.Context;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using HealthBuddyApp.Repository;
using HealthBuddyApp.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;

namespace HealthBuddyApp.Service.Implementation
{
    public class AppointmentServiceImpl : IAppointmentService
    {
        private IMapper _mapper;
        private IDoctorRepository _doctorRepository;
        private IHospitalRepository _hospitalRepository;
        private IPatientRepository _patientRepository;
        private IAppointmentRepository _appointmentRepository;
        private AppDBContext context;
        public AppointmentServiceImpl(IAppointmentRepository appointmentRepository,IHospitalRepository hospitalRepository,IDoctorRepository repository, IPatientRepository patientRepository, IMapper mapper, AppDBContext context)
        {
            _doctorRepository = repository;
            _hospitalRepository = hospitalRepository;
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;

            _mapper = mapper;

            this.context = context;
        }
        public string bookAppointment(AppointmentReqDto appointment)
        {
            string msg = "";
            //TimeSlot timeSlot = new TimeSlot();
            Hospital hospital = context.Hospitals.Include(h => h.Doctors).FirstOrDefault(h => h.Id == appointment.HospitalId);
            if (hospital == null)
            {
                 return "Hospital Not found with Id : " + appointment.HospitalId;
            }
            Doctor doctor = context.Doctors.FirstOrDefault(h => h.Id == appointment.DoctorId);
            if (doctor == null)
            {
                return "Doctor Not found with Id : " + appointment.DoctorId;
            }
            Patient patient = context.Patients.FirstOrDefault(p => p.Id == appointment.PatientId);
            if (patient == null)
            {
                return "Patient Not found with Id : " + appointment.PatientId;
            }

            // Set start time for the time slot
            var timeSlot = new TimeSlot
            {
                StartTime = TimeSpan.Parse(appointment.TimeSlot) // Parse time in HH:mm format
            };
            context.TimeSlots.Add(timeSlot);

            // Fetch booked time slots for the given doctor and date
            var bookedTimeSlots = _appointmentRepository
                .findBookedTimeSlotsByDoctorAndDate(
                    doctor.Id,
                    DateTime.Parse(appointment.AppointmentDate)) // Parse date in yyyy-MM-dd format
                .Select(appointment => appointment.TimeSlot.StartTime)
                .ToList();
            if (bookedTimeSlots.Any(t => t.CompareTo(timeSlot.StartTime) == 0))
            {
                return "TimeSlotNOtAvailable";
            }

            //Appointment appointment1 = _mapper.Map<Appointment>(appointment);
            Appointment appointment1 = new Appointment();
            appointment1.TimeSlot = timeSlot;
            appointment1.AppointementDate = DateTime.Parse(appointment.AppointmentDate);
            appointment1.Doctor = doctor;
            appointment1.Patient = patient;
            appointment1.Hospital = hospital;
            appointment1.Status = AppointmentStatus.PENDING;

            context.Appointments.Add(appointment1);
            if (context.SaveChanges() > 0)
            {
                return "Appointment booked";
            }
            return "Appointment Not booked";
        }

        public string cancleAppointment(long appointId)
        {
            Appointment appointment = context.Appointments
                        .FirstOrDefault(a => a.Id == appointId);

            appointment.Status = AppointmentStatus.CANCELLED;

            if (context.SaveChanges() > 0)
            {
                return "Appointment CANCELLED";
            }
            return "Appointment Not CANCELLED";
        }

        public string completeAppointment(long appointId)
        {
            Appointment appointment = context.Appointments
                        .Include(a => a.Patient)
                        .Include(a => a.Hospital)
                        .Include(a => a.Doctor)
                        .Include(a => a.TimeSlot)
                        .FirstOrDefault(a => a.Id == appointId);

            if (appointment == null)
            {
                return "Fail";
            }
            appointment.Status = AppointmentStatus.COMPLETED;
            if(context.SaveChanges() > 0)
            {
                return "Completed";
            }
            return "Fail";

        }

        public List<AppointmentResDto> getAllAppointments()
        {
            var appointments = context.Appointments
                        .Include(a => a.Patient)
                        .Include(a => a.Hospital)
                        .Include(a => a.Doctor)
                        .Include(a => a.TimeSlot)
                        .ToList();
            return appointments.Select(a => new AppointmentResDto
            {
                Id = a.Id,
                DoctorName = a.Doctor?.Name,
                HospitalName = a.Hospital?.Name,
                PatientName = $"{a.Patient?.FirstName} {a.Patient?.LastName}",
                StartTime = a.TimeSlot.StartTime.ToString(),
                Status = a.Status
            }).ToList();


            //return appointments.Select(a => _mapper.Map<AppointmentResDto>(a)).ToList();
        }
        public AppointmentResDto getAppointment(long id)
        {
            Appointment appointment = context.Appointments
                        .Include(a => a.Patient)
                        .Include(a => a.Hospital)
                        .Include(a => a.Doctor)
                        .Include(a => a.TimeSlot)
                        .FirstOrDefault(a => a.Id == id);

            if(appointment  == null)
            {
                return null;
            }

            var appointmentResDto = new AppointmentResDto
            {
                Id = appointment.Id,
                DoctorName = appointment.Doctor?.Name,
                HospitalName = appointment.Hospital?.Name,
                PatientName = $"{appointment.Patient?.FirstName} {appointment.Patient?.LastName}",
                StartTime = appointment.TimeSlot.StartTime.ToString(),
                Status = appointment.Status
            };
            return appointmentResDto;

        }

        public List<AppointmentResDto> getAppointmentsByDoctorId(long doctorId)
        {
            List<Appointment> appointments = context.Appointments
                       .Include(a => a.Patient)
                       .Include(a => a.Hospital)
                       .Include(a => a.Doctor)
                       .Include(a => a.TimeSlot)
                       .Where(a => a.DoctorId == doctorId)
                       .ToList();

            //return appointments.Select( a => _mapper.Map<AppointmentResDto>(a)).ToList();

            return appointments.Select(a => new AppointmentResDto
            {
                Id = a.Id,
                DoctorName = a.Doctor?.Name,
                HospitalName = a.Hospital?.Name,
                PatientName = $"{a.Patient?.FirstName} {a.Patient?.LastName}",
                StartTime = a.TimeSlot.StartTime.ToString(),
                Status = a.Status
            }).ToList();
        }

        public List<AppointmentResDto> getAppointmentsByHospitalId(long hospId)
        {
            List<Appointment> appointments = context.Appointments
                       .Include(a => a.Patient)
                       .Include(a => a.Hospital)
                       .Include(a => a.Doctor)
                       .Include(a => a.TimeSlot)
                       .Where(a => a.HospitalId == hospId)
                       .ToList();

            // return appointments.Select(a => _mapper.Map<AppointmentResDto>(a)).ToList();
            return appointments.Select(a => new AppointmentResDto
            {
                Id = a.Id,
                DoctorName = a.Doctor?.Name,
                HospitalName = a.Hospital?.Name,
                PatientName = $"{a.Patient?.FirstName} {a.Patient?.LastName}",
                StartTime = a.TimeSlot.StartTime.ToString(),
                Status = a.Status
            }).ToList();
        }

        public List<AppointmentResDto> getAppointmentsBypatientId(long patientId)
        {
            List<Appointment> appointments = context.Appointments
                       .Include(a => a.Patient)
                       .Include(a => a.Hospital)
                       .Include(a => a.Doctor)
                       .Include(a => a.TimeSlot)
                       .Where(a => a.PatientId == patientId)
                       .ToList();

            // return appointments.Select(a => _mapper.Map<AppointmentResDto>(a)).ToList();
            return appointments.Select(a => new AppointmentResDto
            {
                Id = a.Id,
                DoctorName = a.Doctor?.Name,
                HospitalName = a.Hospital?.Name,
                PatientName = $"{a.Patient?.FirstName} {a.Patient?.LastName}",
                StartTime = a.TimeSlot.StartTime.ToString(),
                Status = a.Status
            }).ToList();
        }
    }
}
