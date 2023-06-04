using Microsoft.EntityFrameworkCore;
using MortgageAutomation.Models;

namespace MortgageAutomation.Context
{
    public class MortgageDbContext : DbContext
    {
        public MortgageDbContext(DbContextOptions<MortgageDbContext> options) : base(options)
        {
        }

        public DbSet<CreditCard> Cards { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<IdentityProof> IdentityProofs { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().ToTable("CreditCard");
            modelBuilder.Entity<PersonalDetails>().ToTable("PersonalDetails");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Asset>().ToTable("Asset");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<IdentityProof>().ToTable("IdentityProof");
            modelBuilder.Entity<Income>().ToTable("Income");
            modelBuilder.Entity<Investment>().ToTable("Investment");
            modelBuilder.Entity<Loan>().ToTable("Loan");
            modelBuilder.Entity<Property>().ToTable("Property");
        }
    }
}
