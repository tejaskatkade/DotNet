
using HariomToppersAcademy.Entity;
using Microsoft.EntityFrameworkCore;

namespace HariomToppersAcademy.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) 
        {
        
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<CourseName> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
.HasMany(s => s.courseNames)
.WithMany(c => c.Students)
.UsingEntity(j => j.ToTable("StudentCourse"));
        }
    }
}
