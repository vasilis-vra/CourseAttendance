using CourseAttendanceAPI.Data;
using CourseAttendanceAPI.Dtos;
using CourseAttendanceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CourseAttendanceAPI.Services.Implementations
{
    public class CourseStudentService : ICourseStudentService
    {
        private readonly AppDbContext _context;

        public CourseStudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CourseStudentDto> CreateEnrollment(CourseStudentDto enrollmentDto)
        {
            if (enrollmentDto == null)
            {
                throw new ArgumentNullException(nameof(enrollmentDto));
            }

            CourseStudent newEnrollment = new CourseStudent();
            newEnrollment.CourseId = enrollmentDto.CourseId;
            newEnrollment.StudentId = enrollmentDto.StudentId;

            _context.Enrollments.Add(newEnrollment);
            await _context.SaveChangesAsync();

            return new CourseStudentDto(newEnrollment);
        }

        public async Task<bool> DeleteEnrollment(CourseStudentDto enrollmentDto)
        {
            if (enrollmentDto == null)
            {
                throw new ArgumentNullException(nameof(enrollmentDto));
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.CourseId == enrollmentDto.CourseId || e.StudentId == enrollmentDto.StudentId);
            if (enrollment == null) return false;
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseStudentDto>> GetEnrollmentsByCourseId(Guid courseId)
        {
            if (courseId == null)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var courseEnrollments = await _context.Enrollments
                .Where(e => e.CourseId == courseId).ToListAsync();
            return enrollmentDtos(courseEnrollments);
        }

        public async Task<IEnumerable<CourseStudentDto>> GetEnrollmentsByStudentId(Guid studentId)
        {
            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            var courseEnrollments = await _context.Enrollments
                .Where(e => e.StudentId == studentId).ToListAsync();
            return enrollmentDtos(courseEnrollments);
        }

        private IEnumerable<CourseStudentDto> enrollmentDtos(List<CourseStudent> enrollments)
        {
            List<CourseStudentDto> enrollmentDtos = new List<CourseStudentDto>();
            enrollments.ForEach(enrollment => enrollmentDtos.Add(new CourseStudentDto(enrollment)));
            return enrollmentDtos;
        }
    }
}
