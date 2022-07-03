using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services.Implementations
{
    public class CourseService : ICourseService
    {
        public Task<CourseDto> CreateCourse(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseDto>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto> GetCourseById(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
