using Microsoft.EntityFrameworkCore;
using StudentProfile_RazorPages.Model;

namespace StudentProfile_RazorPages.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student>StudentsTable { get; set; }
    }
}
