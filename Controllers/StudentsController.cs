using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseAttendanceAPI.Data;
using CourseAttendanceAPI.Models;
using CourseAttendanceAPI.Services;
using CourseAttendanceAPI.Dtos;
using CourseAttendanceAPI.Exceptions;

namespace CourseAttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentService.GetAllStudents();

            if (!students.Any())
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentDto studentDto)
        {
            var newStudent = await _studentService.CreateStudent(studentDto);
            if (newStudent.Id == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetStudent", new { id = studentDto.Id }, studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            bool isDeleted = await _studentService.DeleteStudent(id);

            if (isDeleted == false)
            {
                throw new OperationFailedException("Could not delete selected student.");
            }

            return Ok();
        }
    }
}
