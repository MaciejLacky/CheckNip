using Newtonsoft.Json;

namespace CheckNip.Models
{
    public class Person
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("PESEL")]
        public string? pesel { get; set; }

        [JsonProperty("nip")]      
        public string? Nip { get; set; }

        [JsonProperty("companyName")]
        public string? CompanyName { get; set; }
    }
}
