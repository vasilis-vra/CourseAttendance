using CourseAttendanceAPI.Data;
using CourseAttendanceAPI.Dtos;
using CourseAttendanceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAttendanceAPI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentDto> CreateStudent(StudentDto studentDto)
        {
            if (studentDto == null)
            {
                throw new ArgumentNullException(nameof(studentDto));
            }

            Student newStudent = new Student();
            newStudent.FirstName = studentDto.FirstName;
            newStudent.LastName = studentDto.LastName;
            newStudent.Email = studentDto.Email;

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            return new StudentDto(newStudent);
        }

        public async Task<bool> DeleteStudent(Guid studentId)
        {
            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var students = await _context.Students.ToListAsync();
            return studentDtos(students);
        }

        public async Task<StudentDto>? GetStudentById(Guid studentId)
        {
            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            return new StudentDto(student);
        }

        private IEnumerable<StudentDto> studentDtos(List<Student> students)
        {
            List<StudentDto> studentDtos = new List<StudentDto>();
            students.ForEach(student => studentDtos.Add(new StudentDto(student)));
            return studentDtos;
        }
    }
}
