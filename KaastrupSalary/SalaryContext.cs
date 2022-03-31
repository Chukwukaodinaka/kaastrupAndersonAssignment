using Microsoft.EntityFrameworkCore;

namespace SalaryHours
{
    class SalaryContext : DbContext
    {
        public DbSet<Salary> salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=ec2-52-201-124-168.compute-1.amazonaws.com;User ID=jvunrykizxyjdw;Password=1adc74ed6da3653f5a1d745abafdd41e6cf5c0fe709e32a12ce9d5f60e7ffb29;Database=dcs4b1r4b30653;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;");
    }
}