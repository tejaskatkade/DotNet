using System.Numerics;
using HealthBuddyApp.Context;
using HealthBuddyApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyApp.Repository.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDBContext dbContext;
        public DoctorRepository(AppDBContext dBContext ) {
        
            this.dbContext = dBContext;
        }
        public string activateDoctor(long doctorId)
        {
            Doctor doctor = dbContext.Doctors.Include(d => d.User)
                                    .FirstOrDefault(d => d.Id == doctorId);

            doctor.User.IsActive = true;

            dbContext.SaveChanges();
            return "Doctor Inactivated";
        }

        public string addDoctor(Doctor doctor)
        {

            dbContext.Doctors.Add(doctor);
            if(dbContext.SaveChanges() > 0 )
            {
                return "Doctor Addded";
            }
                return "Doctor Not Addded";
        }

        public List<Doctor> findDoctorsByHospitalId(long hosplId)
        {
            return dbContext.Hospitals.Include(h => h.Doctors).FirstOrDefault(hosp => hosp.Id == hosplId).Doctors.ToList();
        }

        public List<Doctor> getAllActiveDoctors()
        {
            return dbContext.Doctors.Where(d => d.User.IsActive == true)
                                    .Include(h => h.Hospitals)                
                                    .Include(h => h.Appointments)
                                    .ToList();
        }

        public List<Doctor> getAllDoctors()
        {
            return dbContext.Doctors.Include(h => h.Hospitals)
                                    .Include(h => h.Appointments)
                                    .ToList();

        }

        public Doctor getDoctorById(long doctorID)
        {
            return dbContext.Doctors.Include(h => h.Hospitals)
                                    .Include(h => h.Appointments)
                                    .Include(d => d.User )
                                    .FirstOrDefault(d => d.Id == doctorID);
        }

        public List<Doctor> getDoctorsByHospital(long hospId)
        {
            return dbContext.Doctors.Include(h => h.Hospitals)
                                    .Where(d => d.Hospitals.Any(h => h.Id == hospId))
                                    .Include(h => h.Appointments)
                                    .ToList();
        }

        public string inActivateDoctor(long doctorId)
        {
            Doctor doctor = dbContext.Doctors.Include(h => h.User)
                                    .FirstOrDefault(d => d.Id == doctorId);

            doctor.User.IsActive = false;

            dbContext.SaveChanges();
            return "Doctor Inactivated";
        }

        public string updateDoctor(long doctorId, Doctor newDoctor)
        {
            Doctor doctor = getDoctorById(doctorId);

            doctor.Name = newDoctor.Name;
            doctor.Specialization = newDoctor.Specialization;
            doctor.Experience = newDoctor.Experience;
            doctor.Email = newDoctor.Email;
            doctor.User.Password = newDoctor.User.Password;
            doctor.Contact = newDoctor.Contact;

            
            if (dbContext.SaveChanges() > 0)
            {
                return "Doctor Addded";
            }
            return "Doctor Not Updated";
        }
    }
}
