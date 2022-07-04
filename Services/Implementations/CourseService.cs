using CourseAttendanceAPI.Data;
using CourseAttendanceAPI.Dtos;
using CourseAttendanceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAttendanceAPI.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CourseDto> CreateCourse(CourseDto courseDto)
        {
            if (courseDto == null)
            {
                throw new ArgumentNullException(nameof(courseDto));
            }

            Course newCourse = new Course();
            newCourse.Name = courseDto.Name;
            newCourse.Description = courseDto.Description;
            newCourse.Semester = courseDto.Semester;

            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();

            return new CourseDto(newCourse);
        }

        public async Task<bool> DeleteCourse(Guid courseId)
        {
            if (courseId == null)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) return false;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courseDtos(courses);

        }

        public async Task<CourseDto>? GetCourseById(Guid courseId)
        {
            if (courseId == null)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            return new CourseDto(course);
        }

        private IEnumerable<CourseDto> courseDtos(List<Course> courses)
        {
            List<CourseDto> courseDtos = new List<CourseDto>();
            courses.ForEach(course => courseDtos.Add(new CourseDto(course)));
            return courseDtos;
        }
    }
}
