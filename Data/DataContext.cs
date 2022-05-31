using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Zadanie> Zadanies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tasks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var model = new Zadanie[]
            {
                new Zadanie { ZadanieId = 1, NazwaZadania = "Prime", WartośćDoPoliczenia = 3, status = false }
            };

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Zadanie>().HasData(model); //ToTable("Zadanie");
        }
    }
}
