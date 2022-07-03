using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services
{
    public interface IStudentService
    {
        public Task<StudentDto> CreateStudent(StudentDto studentDto);

        public Task<StudentDto> GetStudentById(Guid studentId);

        public Task<List<StudentDto>> GetAllStudents();

        public Task<bool> DeleteStudent(Guid studentId);
    }
}
