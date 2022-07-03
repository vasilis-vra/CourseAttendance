using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        public Task<EnrollmentDto> CreateEnrollment(EnrollmentDto enrollmentDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEnrollment(EnrollmentDto enrollmentDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<EnrollmentDto>> GetEnrollmentsByCourseId(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EnrollmentDto>> GetEnrollmentsByStudentId(Guid studentId)
        {
            throw new NotImplementedException();
        }
    }
}
