using StudentPointsApi.Models;

namespace StudentPointsApi.Extensions
{
    public static class StudentExtensions
    {
        public static Student GetStudentToCheck(this List<Student> students, string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                                               x.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            return student; 
        }
    }
}
