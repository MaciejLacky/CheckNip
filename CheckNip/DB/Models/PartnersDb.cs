using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CheckNip.DB.Models
{
    public class PartnersDb
    {
        [Key]
        public int Id { get; set; }
       
        public string? FirstName { get; set; }
      
        public string? LastName { get; set; }
       
        public string? pesel { get; set; }
      
        public string? Nip { get; set; }
      
        public string? CompanyName { get; set; }

        public SubjectDb Subject { get; set; }

    }
}
