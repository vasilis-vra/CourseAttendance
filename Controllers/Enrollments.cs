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
    public class Enrollments : ControllerBase
    {
        private ICourseStudentService _courseStudentService;

        public Enrollments(ICourseStudentService courseStudentService)
        {
            _courseStudentService = courseStudentService;
        }

        [HttpGet("/course/{id}")]
        public async Task<ActionResult<CourseStudentDto>> GetEnrollmentByCourseId(Guid id)
        {
            var enrollments = await _courseStudentService.GetEnrollmentsByCourseId(id);

            if (!enrollments.Any())
            {
                return NotFound();
            }

            return Ok(enrollments);
        }

        [HttpGet("/student/{id}")]
        public async Task<ActionResult<CourseStudentDto>> GetEnrollmentByStudentId(Guid id)
        {
            var enrollments = await _courseStudentService.GetEnrollmentsByStudentId(id);

            if (!enrollments.Any())
            {
                return NotFound();
            }

            return Ok(enrollments);
        }

        [HttpPost]
        public async Task<ActionResult<CourseStudentDto>> PostCourseStudent(CourseStudentDto courseStudentDto)
        {
            var newEnrollment = await _courseStudentService.CreateEnrollment(courseStudentDto);
            if (newEnrollment.CourseId == null || newEnrollment.StudentId == null)
            {
                throw new OperationFailedException("Failed not enroll to the specified course.");
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourseStudent([FromBody] CourseStudentDto courseStudentDto)
        {
            bool isDeleted = await _courseStudentService.DeleteEnrollment(courseStudentDto);

            if (isDeleted == false)
            {
                throw new OperationFailedException("Could not delete selected enrollment.");
            }

            return Ok();
        }
    }
}
