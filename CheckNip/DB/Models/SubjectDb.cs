﻿using CheckNip.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckNip.DB.Models
{
    public class SubjectDb
    {
        [Key]
        public int Id { get; set; }

        public string? Regon { get; set; }

        public DateTime? RestorationDate { get; set; }

        public string? WorkingAddress { get; set; }

        public bool? HasVirtualAccounts { get; set; }

        public string? StatusVat { get; set; }

        public string? Krs { get; set; }

        public string? RestorationBasis { get; set; }

        public string? RegistrationDenialBasis { get; set; }
       
        public string Nip { get; set; }
       
        public DateTime? RemovalDate { get; set; }

        public string Name { get; set; }

        public DateTime? RegistrationLegalDate { get; set; }
       
        public string? RemovalBasis { get; set; }

        public string? Pesel { get; set; }
     
        public string? ResidenceAddress { get; set; }
      
        public DateTime? RegistrationDenialDate { get; set; }

        public List<PartnersDb>? Partners { get; set; }
        public List<RepresentativesDb>? Representatives { get; set; }
        public List<BankAccountDb>? AccountNumbers { get; set; }

    }
}
