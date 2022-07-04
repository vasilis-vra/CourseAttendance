using CourseAttendanceAPI.Exceptions;
using CourseAttendanceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseAttendanceAPI.Dtos
{
    public class CourseDto
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string? Description { get; set; }

        public string? Semester { get; set; }

        public CourseDto()
        {
        }

        public CourseDto(Course course)
        {
            if (course != null)
            {
                Id = course.Id;
                Name = course.Name;
                Description = course.Description;
                Semester = course.Semester;
            }
            else
            {
                throw new InvalidModelException("Invalid model input to CourseDto constructor.");
            }
        }
    }
}
