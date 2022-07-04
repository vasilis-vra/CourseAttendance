using CourseAttendanceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAttendanceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseStudent> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });
            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(cs => cs.Students)
                .HasForeignKey(cs => cs.CourseId);
            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(cs => cs.Courses)
                .HasForeignKey(cs => cs.StudentId);
        }
    }
}