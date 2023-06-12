using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckNip.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [JsonProperty("regon")]
        [DisplayName("REGON")]
        public string? Regon { get; set; }

        [JsonProperty("restorationDate")]
        [DisplayName("Data przywrócenia jako podatnika VAT")]
        public DateTime? RestorationDate { get; set; }

        [JsonProperty("workingAddress")]
        [DisplayName("Adres rejestracyjny")]
        public string? WorkingAddress { get; set; }

        [JsonProperty("hasVirtualAccounts")]
        [DisplayName("Podmiot posiada maski kont wirtualnych")]
        public bool HasVirtualAccounts { get; set; }

        [JsonProperty("statusVat")]
        [DisplayName("Status podatnika VAT")]
        public string? StatusVat { get; set; }

        [JsonProperty("krs")]
        [DisplayName("numer KRS jeżeli został nadany")]
        public string? Krs { get; set; }

        [JsonProperty("restorationBasis")]
        [DisplayName("Podstawa prawna przywrócenia jako podatnika VAT")]
        public string? RestorationBasis { get; set; }

        [JsonProperty("accountNumbers")]
        [DisplayName("Numery kont bankowych")]
        public List<string>? AccountNumbers { get; set; }

        [JsonProperty("registrationDenialBasis")]
        [DisplayName("Podstawa prawna odmowy rejestracji")]
        public string? RegistrationDenialBasis { get; set; }

        [JsonProperty("nip")]
        [DisplayName("NIP")]
        public string? Nip { get; set; }

        [JsonProperty("removalDate")]
        [DisplayName("Data wykreślenia odmowy rejestracji jako podatnika VAT")]
        public DateTime? RemovalDate { get; set; }

        [JsonProperty("partners")]
        [DisplayName("Imiona i nazwiska lub firmę (nazwa) wspólnika")]
        public List<Person>? Partners { get; set; }

        [JsonProperty("name")]
        [DisplayName("Firma (nazwa) lub imię i nazwisko")]
        public string? Name { get; set; }

        [JsonProperty("registrationLegalDate")]
        [DisplayName("Data rejestracji jako podatnika VAT ")]
        public DateTime? RegistrationLegalDate { get; set; }

        [JsonProperty("removalBasis")]
        [DisplayName("Podstawa prawna wykreślenia odmowy rejestracji jako podatnika VAT")]
        public string? RemovalBasis { get; set; }

        [JsonProperty("pesel")]
        [DisplayName("PESEL")]
        public string? Pesel { get; set; }

        [JsonProperty("representatives")]
        [DisplayName("Imiona i nazwiska osób wchodzących w skład organu uprawnionego do reprezentowania podmiotu")]
        public List<Person>? Representatives { get; set; }

        [JsonProperty("residenceAddress")]
        [DisplayName("Adres siedziby działalności gospodarczej")]
        public string? ResidenceAddress { get; set; }

        [JsonProperty("registrationDenialDate")]
        [DisplayName("Data odmowy rejestracji jako podatnika VAT format")]
        public DateTime? RegistrationDenialDate { get; set; }


    }
}
