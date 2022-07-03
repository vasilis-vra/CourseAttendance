using CourseAttendanceAPI.Dtos;

namespace CourseAttendanceAPI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        public Task<StudentDto> CreateStudent(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentDto>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> GetStudentById(Guid studentId)
        {
            throw new NotImplementedException();
        }
    }
}
