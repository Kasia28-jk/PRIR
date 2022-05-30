using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    internal class DataContext : DbContext
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
