using StudentPointsApi.Models;

namespace StudentPointsApi.Repository.Interfaces
{
    public interface IJsonService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetStudentByFullNameAsync(string firstName, string lastName);
        Task UpdateStudentAsync(string firstName, string lastName,Student student);
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(string firstName, string LastName);
    }
}
