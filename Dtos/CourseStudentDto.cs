using CourseAttendanceAPI.Exceptions;
using CourseAttendanceAPI.Models;

namespace CourseAttendanceAPI.Dtos
{
    public class CourseStudentDto
    {
        public Guid CourseId { get; set; }

        public Guid StudentId { get; set; }

        public CourseStudentDto()
        {
        }

        public CourseStudentDto(CourseStudent courseStudent)
        {
            if (courseStudent == null)
            {
                throw new InvalidModelException("Invalid model input to CourseStudentDto constructor.");
            }

            CourseId = courseStudent.CourseId;
            StudentId = courseStudent.StudentId;
        }

        public IEnumerable<CourseStudentDto> enrollmentDtos(List<CourseStudent> enrollments)
        {
            List<CourseStudentDto> enrollmentDtos = new List<CourseStudentDto>();
            enrollments.ForEach(enrollment => enrollmentDtos.Add(new CourseStudentDto(enrollment)));
            return enrollmentDtos;
        }
    }
}
