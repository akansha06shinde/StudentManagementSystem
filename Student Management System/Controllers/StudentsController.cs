using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_Management_System.DTOs;
using Student_Management_System.Models;
using Student_Management_System.Service;
using System.Security.Claims;

namespace Student_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _service.GetAllStudentsAsync();

            return Ok(new
            {
                message = "Students fetched successfully",
                data = students
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            return Ok(student);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.UtcNow
            };

            await _service.AddStudentAsync(student);

            return Ok(new
            {
                message = "Student created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto dto)
        {
            var existingStudent = await _service.GetStudentByIdAsync(id);

            if (existingStudent == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            existingStudent.Name = dto.Name;
            existingStudent.Email = dto.Email;
            existingStudent.Age = dto.Age;
            existingStudent.Course = dto.Course;

            await _service.UpdateStudentAsync(existingStudent);

            return Ok(new
            {
                message = "Student updated successfully"
            });
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingStudent = await _service.GetStudentByIdAsync(id);

            if (existingStudent == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            await _service.DeleteStudentAsync(id);

            return Ok(new
            {
                message = "Student deleted successfully"
            });
        }

        [HttpGet("me")]
        public IActionResult GetMyIdentity()
        {
            var studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var name = User.FindFirst(ClaimTypes.Name)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(studentId))
            {
                return Unauthorized(new
                {
                    message = "Invalid token"
                });
            }

            return Ok(new
            {
                message = "Token is valid",
                studentId,
                name,
                email
            });
        }
    }
}