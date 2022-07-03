using System.ComponentModel.DataAnnotations;

namespace CourseAttendanceAPI.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string? Description { get; set; }

        public string? Semester { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
