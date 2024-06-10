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
            await JsonService.AddStudentAsync(student);
            
            return Ok("Student added");
        }
        [HttpPost("DeleteStudent/{firstName}")]
        public async Task<IActionResult> DeleteStudent(string firstName, string lastName)
        {
            await JsonService.DeleteStudentAsync(firstName,lastName);

            return Ok("Student deleted!");
        }

        [HttpPut("UpdateStudent/{firstName}/{lastName}")]
        public async Task<IActionResult> UpdateStudent(string firstName, string lastName, Student student)
        {
            await JsonService.UpdateStudentAsync(firstName, lastName, student);

            return Ok("Student Updated!");
        }
    }
}
