﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp1;

namespace WpfApp1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220530212537_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WpfApp1.Zadanie", b =>
                {
                    b.Property<int>("ZadanieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazwaZadania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WartośćDoPoliczenia")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("ZadanieId");

                    b.ToTable("Zadanies");

                    b.HasData(
                        new
                        {
                            ZadanieId = 1,
                            NazwaZadania = "Prime",
                            WartośćDoPoliczenia = 3,
                            status = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
