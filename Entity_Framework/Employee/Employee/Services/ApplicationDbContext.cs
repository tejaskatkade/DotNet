
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Emp> employees { get; set; }
    }
}
