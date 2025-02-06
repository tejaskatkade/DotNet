using HealthBuddyApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthBuddyApp.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> Options):base (Options)
        {
            
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users  {get; set;}
        public DbSet<Appointment> Appointments {get; set;}
        public DbSet<TimeSlot> TimeSlots {get; set;}
        public DbSet<Patient> Patients {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // hospital <-> doctor

            modelBuilder.Entity<Hospital>()
                .HasMany<Doctor>(h => h.Doctors)
                .WithMany(d => d.Hospitals)
                .UsingEntity(hd => hd.ToTable("hospital_doctor"));

            // 1. One-to-One: Patient <-> User
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserId);
            //.OnDelete(DeleteBehavior.Cascade);

            // 2. One-to-Many: Patient <-> Appointments
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3 One-to-Many: Doctor <-> Appointments
            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            // 4. One-to-Many: Hospital <-> Appointments

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Hospital)
                .WithOne()
                .HasForeignKey<Appointment>(a => a.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);

            



            // . One-to-One: Appointment ↔ TimeSlot
           /* modelBuilder.Entity<Appointment>()
                .HasOne(a => a.TimeSlot)
                .WithOne()
                .HasForeignKey<Appointment>(a => a.TimeSlotId);*/


            // enums
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>()
                .HasColumnType("ENUM('CANCELLED', 'COMPLETED', 'PENDING')");
                

            
            modelBuilder.Entity<Patient>()
                .Property(p => p.Gender)
                .HasConversion<string>()
                .HasColumnType("ENUM('MALE', 'FEMALE')");

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>()
                .HasColumnType("ENUM('ROLE_ADMIN','ROLE_DOCTOR','ROLE_PATIENT')");


        }
    }
}
