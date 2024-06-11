using Microsoft.AspNetCore.Mvc;
using StudentPointsApi.Models;
using StudentPointsApi.Repository.Interfaces;

namespace StudentPointsApi.Controllers
{
    public class StudentController : BaseController
    {
        public StudentController(IJsonService jsonService) : base(jsonService)
        {
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await JsonService.GetAllAsync();
            if(students is null ||students.Count < 1)
            {
                return NotFound("Students not found!");
            }
            return Ok(students);
        }

        [HttpGet("GetStudentByFullName")]
        public async Task<IActionResult> GetStudentByFullName(string firstName, string lastName)
        {
            var student = await JsonService.GetStudentByFullNameAsync(firstName,lastName);
            if (student is null)
            {
                return NotFound("Student not found!");
            }
            return Ok(student);
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var addStudent = await JsonService.AddStudentAsync(student);
            if (addStudent)
            {
                return Ok("Student added.");
            }
            return BadRequest("Student already exists!");

        }
        [HttpPost("DeleteStudent/{firstName}")]
        public async Task<IActionResult> DeleteStudent(string firstName, string lastName)
        {
            var deleteStudent = await JsonService.DeleteStudentAsync(firstName,lastName);
            if (deleteStudent)
            {
                return Ok("Student deleted.");
            }
            return BadRequest("Failed to delete!");
        }

        [HttpPut("UpdateStudent/{firstName}/{lastName}")]
        public async Task<IActionResult> UpdateStudent(string firstName, string lastName, Student student)
        {
            var updateStudent = await JsonService.UpdateStudentAsync(firstName, lastName, student);
            if (updateStudent)
            {
                return Ok("Student Updated!");
            }

            return BadRequest("Failed to update student!");
        }
    }
}
