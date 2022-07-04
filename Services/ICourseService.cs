using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services
{
    public interface ICourseService
    {
        public Task<CourseDto> CreateCourse(CourseDto courseDto);

        public Task<CourseDto>? GetCourseById(Guid courseId);

        public Task<IEnumerable<CourseDto>> GetAllCourses();

        public Task<bool> DeleteCourse(Guid courseId);
    }
}
