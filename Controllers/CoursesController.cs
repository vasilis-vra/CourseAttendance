using Microsoft.AspNetCore.Mvc;
using CourseAttendanceAPI.Models;
using CourseAttendanceAPI.Services;
using CourseAttendanceAPI.Dtos;
using CourseAttendanceAPI.Exceptions;

namespace CourseAttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();

            if (!courses.Any())
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid id)
        {
            var course = await _courseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseDto courseDto)
        {
            var newCourse = await _courseService.CreateCourse(courseDto);
            if (newCourse.Id == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetCourse", new { id = courseDto.Id }, courseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            bool isDeleted = await _courseService.DeleteCourse(id);

            if (isDeleted == false)
            {
                throw new OperationFailedException("Could not delete selected course.");
            }

            return Ok();
        }
    }
}
