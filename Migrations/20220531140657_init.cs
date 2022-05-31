using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kolejkas",
                columns: table => new
                {
                    KolejkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKolejki = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolejkas", x => x.KolejkaId);
                });

            migrationBuilder.CreateTable(
                name: "Konfiguracjas",
                columns: table => new
                {
                    KonfiguracjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUzytkownika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hasło = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VHostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    NazwaKolejki = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguracjas", x => x.KonfiguracjaId);
                });

            migrationBuilder.CreateTable(
                name: "Zadanies",
                columns: table => new
                {
                    ZadanieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaZadania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WartośćDoPoliczenia = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zadanies", x => x.ZadanieId);
                });

            migrationBuilder.InsertData(
                table: "Kolejkas",
                columns: new[] { "KolejkaId", "NazwaKolejki" },
                values: new object[] { 1, "test2" });

            migrationBuilder.InsertData(
                table: "Konfiguracjas",
                columns: new[] { "KonfiguracjaId", "Hasło", "HostName", "NazwaKolejki", "NazwaUzytkownika", "Port", "VHostName" },
                values: new object[] { 1, "quest", "localhost", "test1", "quest", 5672, "localhost" });

            migrationBuilder.InsertData(
                table: "Zadanies",
                columns: new[] { "ZadanieId", "NazwaZadania", "WartośćDoPoliczenia", "status" },
                values: new object[] { 1, "Prime", 3, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kolejkas");

            migrationBuilder.DropTable(
                name: "Konfiguracjas");

            migrationBuilder.DropTable(
                name: "Zadanies");
        }
    }
}
