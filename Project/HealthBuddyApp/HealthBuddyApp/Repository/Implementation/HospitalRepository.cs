using AutoMapper;
using HealthBuddyApp.Context;
using HealthBuddyApp.DTO.ReqDto;
using HealthBuddyApp.DTO.ResDto;
using HealthBuddyApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyApp.Repository.Implementation
{
    public class HospitalRepository : IHospitalRepository
    {
        // private IMapper mapper;

        private readonly AppDBContext context;
        
        public HospitalRepository(AppDBContext context)
        {
            this.context = context;
        }
        public string activateHospital(long hospId)
        {
            Hospital hospital = context.Hospitals.Include(h => h.Doctors).FirstOrDefault(h => h.Id == hospId);
            if (hospital == null)
            {
                return "Hospital Not found with Id : " + hospId;
            }
            if (hospital.IsActive) 
            {
                return "Hospital Is Already Active";
            }
            hospital.IsActive = true;
            if (context.SaveChanges() > 0)
            {
                return "Hospital Activated";
            }
            return "Hospital Not Activated";
        }

        public string addDoctor(long hospId, long doctorId)
        {
            Hospital hospital = context.Hospitals.Include(h => h.Doctors).FirstOrDefault(h => h.Id == hospId);
            if (hospital == null)
            {
                return "Hospital Not found with Id : " + hospId;
            }
            Doctor doctor = context.Doctors.FirstOrDefault(h => h.Id == doctorId);
            if (doctor == null)
            {
                return "Doctor Not found with Id : " + doctorId;
            }
            hospital.Doctors.Add(doctor);
            if(context.SaveChanges() > 0)
            {
                return "Doctor Added ";
            }
                return "Doctor Not Added ";
        }

        public string addHospital(Hospital hospital)
        {
            context.Hospitals.Add(hospital);
            if (context.SaveChanges() > 0)
            {
                return "Hospital Added ";
            }
                return "Hospital Not Added ";

        }

        public List<Hospital> getActiveHospitals()
        {
            return context.Hospitals.Include(h => h.Doctors).Where(h => h.IsActive == true).ToList();   
        }

        public List<Hospital> getAllHospitals()
        {
            return context.Hospitals.Include(h => h.Doctors).ToList();
        }

        public string inActivateHospital(long hospId)
        {
            Hospital hospital = context.Hospitals.Include(h => h.Doctors).FirstOrDefault(h => h.Id == hospId);
            if (hospital == null)
            {
                return "Hospital Not found with Id : " + hospId;
            }
            if (!hospital.IsActive)
            {
                return "Hospital Is Already InActive";
            }
            hospital.IsActive = false;
            if (context.SaveChanges() > 0)
            {
                return "Hospital InActivated";
            }
            return "Hospital Not InActivated";

        }

        public string removeDoctor(long hospId, long doctorId)
        {
            Hospital hospital = context.Hospitals.Include(h => h.Doctors).FirstOrDefault(h => h.Id == hospId);
            if (hospital == null)
            {
                return "Hospital Not found with Id : " + hospId;
            }
            Doctor doctor = context.Doctors.FirstOrDefault(h => h.Id == doctorId);
            if (doctor == null)
            {
                return "Doctor Not found with Id : " + doctorId;
            }

            Doctor doctor1 = hospital.Doctors.Find(h => h.Id .Equals(doctorId));

            if(doctor1 == null)
            {
                return "Doctor is not belong to hospital with Id"+ hospId;
            }
                hospital.Doctors.Remove(doctor1);
            if (context.SaveChanges() > 0)
            {
                return "Doctor Removed ";
            }
            return "Doctor Removed ";

        }

        public string updateHospital(long hospId, Hospital newHospital)
        {
            Hospital hospital = context.Hospitals.Include(h => h.Doctors).FirstOrDefault(h => h.Id == hospId);
            if (hospital == null)
            {
                return "Hospital Not found with Id : " + hospId;
            }

            hospital.Name = newHospital.Name;
            hospital.Contact = newHospital.Contact;
            hospital.Location = newHospital.Location;


            //context.Hospitals.Add(hospital);
            if (context.SaveChanges() > 0)
            {
                return "Hospital Updated ";
            }
            return "Hospital Not Updated ";
        }
    }
}
