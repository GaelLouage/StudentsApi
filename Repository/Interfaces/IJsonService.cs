using StudentPointsApi.Models;

namespace StudentPointsApi.Repository.Interfaces
{
    public interface IJsonService
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetStudentByFullNameAsync(string firstName, string lastName);
        Task<bool> UpdateStudentAsync(string firstName, string lastName,Student student);
        Task<bool> AddStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(string firstName, string LastName);
    }
}
