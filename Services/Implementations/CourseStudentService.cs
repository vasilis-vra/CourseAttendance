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
        private CourseStudentDto _courseStudentDto;

        public CourseStudentService(AppDbContext context, CourseStudentDto courseStudentDto)
        {
            _context = context;
            _courseStudentDto = courseStudentDto;
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
            return _courseStudentDto.enrollmentDtos(courseEnrollments);
        }

        public async Task<IEnumerable<CourseStudentDto>> GetEnrollmentsByStudentId(Guid studentId)
        {
            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            var courseEnrollments = await _context.Enrollments
                .Where(e => e.StudentId == studentId).ToListAsync();
            return _courseStudentDto.enrollmentDtos(courseEnrollments);
        }
    }
}
