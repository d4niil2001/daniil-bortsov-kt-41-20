using daniil_bortsov_kt_41_20.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace daniil_bortsov_kt_41_20.Database
{
    public class StudentDbContext : DbContext
    {
        DbSet<Models.Group> Groups { get; set; }
        DbSet<Models.Student> Students { get; set; }
        DbSet<Models.Subject> Subjects { get; set; }
        DbSet<Models.Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}
