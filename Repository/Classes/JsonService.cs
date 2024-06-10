using Newtonsoft.Json;
using StudentPointsApi.Models;
using StudentPointsApi.Repository.Interfaces;

namespace StudentPointsApi.Repository.Classes
{
    public class JsonService : IJsonService
    {
        private const string FILE_NAME = "Students.json";
        private string _filePath;
        private List<Student> _students = new List<Student>();

        public async Task<List<Student>> GetAllAsync()
        {
            await ReadJsonFile();
            return _students;
        }
        public async Task AddStudentAsync(Student student)
        {

           await ReadJsonFile();

            var studentToCheck = _students.FirstOrDefault(x => x.FirstName == student.FirstName && x.LastName == student.LastName);
            if (studentToCheck is  null)
            {
                _students.Add(student);
                var converter = JsonConvert.SerializeObject(_students);
             
               await File.WriteAllTextAsync(FILE_NAME, converter);
            }
        }

        public async Task DeleteStudentAsync(string firstName, string lastName)
        {
            
            await ReadJsonFile();
            var studentToCheck = _students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToCheck is not null)
            {
                _students.Remove(studentToCheck);
                var converter = JsonConvert.SerializeObject(_students);

                await File.WriteAllTextAsync(FILE_NAME, converter);
            }
        }
        public async Task<Student>? GetStudentByFullNameAsync(string firstName, string lastName)
        {
            await ReadJsonFile();
            return _students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public async Task UpdateStudentAsync(string firstName, string lastName, Student student)
        {
            await ReadJsonFile();
            var studentToCheck = _students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToCheck is not null)
            {
                _students.Remove(studentToCheck);
                _students.Add(student);
                var converter = JsonConvert.SerializeObject(_students);

                await File.WriteAllTextAsync(FILE_NAME, converter);
            }
        }

        private async Task ReadJsonFile()
        {
            var currentFolder = Environment.CurrentDirectory;
            _filePath = Path.Combine(currentFolder, FILE_NAME);
            var jsonData = await File.ReadAllTextAsync(FILE_NAME);
            _students = JsonConvert.DeserializeObject<List<Student>>(jsonData);
        }
    }
}
