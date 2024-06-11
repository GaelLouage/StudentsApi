using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentPointsApi.Extensions;
using StudentPointsApi.Models;
using StudentPointsApi.Repository.Interfaces;

namespace StudentPointsApi.Repository.Classes
{
    public class JsonService : IJsonService
    {
        private const string FILE_NAME = "Students.json";
        private string? _filePath;
        private List<Student> _students = new List<Student>();

        public async Task<List<Student>> GetAllAsync()
        {
            await ReadJsonFile();
            return _students;
        }
        public async Task<Student> GetStudentByFullNameAsync(string firstName, string lastName)
        {
            await ReadJsonFile();
            return _students.GetStudentToCheck(firstName, lastName);
        }
        public async Task<bool> DeleteStudentAsync(string firstName, string lastName)
        {
            return await StudentActionAsync(firstName, lastName,
            (student) =>
            {
                _students.Remove(student);
            });
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            return await StudentActionAsync(student.FirstName, student.LastName,
            (s) =>
            {
                _students.Remove(s);
                _students.Add(student);
            });
        }
        public async Task<bool> UpdateStudentAsync(string firstName, string lastName, Student student)
        {
            return await StudentActionAsync(firstName, lastName,
            (s) =>
            {
                _students.Remove(s);
                _students.Add(student);
            });
        }

        private async Task ReadJsonFile()
        {
            var currentFolder = Environment.CurrentDirectory;
            _filePath = Path.Combine(currentFolder, FILE_NAME);
            var jsonData = await File.ReadAllTextAsync(FILE_NAME);
            _students = JsonConvert.DeserializeObject<List<Student>>(jsonData);
        }

        private async Task<bool> StudentActionAsync(string firstName, string lastName, Action<Student> action)
        {
            await ReadJsonFile();
            var studentToCheck = _students.GetStudentToCheck(firstName, lastName);
            if (studentToCheck is not null)
            {
                action(studentToCheck);
                var converter = JsonConvert.SerializeObject(_students);

                await File.WriteAllTextAsync(FILE_NAME, converter);
                return true;
            }
            return false;
        }
    }
}
