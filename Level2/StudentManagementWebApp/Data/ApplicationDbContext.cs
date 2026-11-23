
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApp.Models;

namespace StudentManagementWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Represents the Students table in our database
        public DbSet<Student> Students { get; set; }
    }
}
