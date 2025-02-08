using System.Numerics;
using HealthBuddyApp.Context;
using HealthBuddyApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyApp.Repository.Implementation
{
    public class PatientRepository : IPatientRepository
    {
        private AppDBContext context;

        public PatientRepository(AppDBContext context)
        {
            this.context = context;
        }
        public string activatePatient(long patientId)
        {
            Patient patient = getPatientById(patientId);
            if (patient == null)
            {
                return "Patient not found with Id " + patient;
            }
            patient.User.IsActive = true;
            if (context.SaveChanges() > 0)
            {
                return "Patient is Active";
            }
            return "Patient Not Activated";
        }

        public string addPatient(Patient patient)
        {
            
            
            context.Patients.Add(patient);
            if (context.SaveChanges() > 0)
            {
                return "Patient Added";
            }
            return "Patient NOt Added";
        }

        public List<Patient> getAllPatients()
        {
            return context.Patients.Include(p => p.Appointments)
                            .Include(p => p.User)
                            .ToList();
        }

        public Patient getPatientById(long patientId)
        {
            return context.Patients.Include(p => p.Appointments)
                            .Include(p => p.User)
                            .FirstOrDefault(p => p.Id ==  patientId);

        }

        public string inActivatePatient(long patientId)
        {
            Patient patient = getPatientById(patientId);
            if (patient == null)
            {
                return "Patient not found with Id "+ patient;
            }
            patient.User.IsActive = false;
            if (context.SaveChanges() > 0)
            {
                return "Patient is InActive Now ";
            }
            return "Patient Not Inactivated";
            
        }

        public string updatePatient(Patient newPatient)
        {
            Patient patient = getPatientById(newPatient.Id);
            if (patient == null)
            {
                return "Patient not found with Id " + newPatient.Id;
            }

            patient.FirstName = newPatient.FirstName;
            patient.LastName    = newPatient.LastName;
            patient.Address = newPatient.Address;   
            patient.Gender  = newPatient.Gender;
            patient.Age = newPatient.Age;
            patient.UpdatedOn = DateTime.Now;
            patient.Symptoms = newPatient.Symptoms;


            if (context.SaveChanges() > 0)
            {
                return "Patient Added";
            }
            return "Patient NOt Added";
        }
    }
}
