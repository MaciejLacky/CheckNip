using CheckNip.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CheckNip.DB.Models;

namespace CheckNip.DB
{
    public class CheckNipContext : DbContext
    {
        public CheckNipContext(DbContextOptions<CheckNipContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-F3NJMD4\\SQLEXPRESS;Database=checkNIP;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        }
       
        public DbSet<SubjectDb> Subjects { get; set; }
        public DbSet<PartnersDb> Persons { get; set; }
        public DbSet<BankAccountDb> BankAccounts { get; set; }
    }
}
