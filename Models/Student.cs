using System.ComponentModel.DataAnnotations;

namespace CourseAttendanceAPI.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public ICollection<CourseStudent> Courses { get; set; }
    }
}
