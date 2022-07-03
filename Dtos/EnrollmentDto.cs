using CourseAttendanceAPI.Exceptions;

namespace CourseAttendanceAPI.Dtos
{
    public class EnrollmentDto
    {
        public Guid CourseId { get; set; }

        public Guid StudentId { get; set; }

        public EnrollmentDto()
        {
        }

        public EnrollmentDto(Guid courseId, Guid studentId)
        {
            if (courseId == null || studentId == null)
            {
                throw new InvalidModelException("Ids cannot be null when constructing an EnrollmentDto.");
            }

            CourseId = courseId;
            StudentId = studentId;
        }
    }
}
