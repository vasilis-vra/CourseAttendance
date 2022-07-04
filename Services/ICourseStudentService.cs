using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services
{
    public interface ICourseStudentService
    {
        public Task<CourseStudentDto> CreateEnrollment(CourseStudentDto enrollmentDto);
        public Task<bool> DeleteEnrollment(CourseStudentDto enrollmentDto);
        public Task<IEnumerable<CourseStudentDto>> GetEnrollmentsByCourseId(Guid courseId);
        public Task<IEnumerable<CourseStudentDto>> GetEnrollmentsByStudentId(Guid studentId);

    }
}
