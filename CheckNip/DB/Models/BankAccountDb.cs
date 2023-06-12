using System.ComponentModel.DataAnnotations;

namespace CheckNip.DB.Models
{
    public class BankAccountDb
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; }

        public SubjectDb Subject { get; set; }
    }
}
