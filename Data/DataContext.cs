using Microsoft.EntityFrameworkCore;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Zadanie> Zadanies { get; set; }
        public DbSet<Kolejka> Kolejkas { get; set; }
        public DbSet<Konfiguracja> Konfiguracjas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tasks;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var model = new Zadanie[]
            {
                new Zadanie { ZadanieId = 1, NazwaZadania = "Prime", WartośćDoPoliczenia = 3, status = false }
            };

            var model2 = new Kolejka[]
            {
                new Kolejka { KolejkaId = 1, NazwaKolejki = "test2"}
            };

            var model3 = new Konfiguracja[]
            {
                new Konfiguracja { KonfiguracjaId = 1,NazwaUzytkownika ="quest", Hasło = "quest", HostName ="localhost", VHostName = "localhost",Port = 5672, NazwaKolejki = "test1"}
            };

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Zadanie>().HasData(model); //ToTable("Zadanie");
            modelBuilder.Entity<Kolejka>().HasData(model2);
            modelBuilder.Entity<Konfiguracja>().HasData(model3);
        }
    }
}
