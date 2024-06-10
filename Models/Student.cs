using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace StudentPointsApi.Models
{
    public class Student
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("points")]
        public int Points { get; set; }
    }
}
