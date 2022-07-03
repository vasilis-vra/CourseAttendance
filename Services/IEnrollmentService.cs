using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services
{
    public interface IEnrollmentService
    {
        public Task<EnrollmentDto> CreateEnrollment(EnrollmentDto enrollmentDto);
        public Task<bool> DeleteEnrollment(EnrollmentDto enrollmentDto);
        public Task<List<EnrollmentDto>> GetEnrollmentsByCourseId(Guid courseId);
        public Task<List<EnrollmentDto>> GetEnrollmentsByStudentId(Guid studentId);

    }
}
