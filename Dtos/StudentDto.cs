using CourseAttendanceAPI.Exceptions;
using CourseAttendanceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseAttendanceAPI.Dtos
{
    public class StudentDto
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

        public StudentDto()
        {
        }

        public StudentDto(Student student)
        {
            if (student != null)
            {
                Id = student.Id;
                FirstName = student.FirstName;
                LastName = student.LastName;
                Email = student.Email;
            }
            else
            {
                throw new InvalidModelException("Invalid model input to StudentDto constructor.");
            }
        }
    }
}
