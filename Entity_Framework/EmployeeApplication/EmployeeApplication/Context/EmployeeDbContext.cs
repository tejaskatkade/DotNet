using EmployeeApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplication.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {
                
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
