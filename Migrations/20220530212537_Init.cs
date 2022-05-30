using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Zadanies",
                columns: new[] { "ZadanieId", "NazwaZadania", "WartośćDoPoliczenia", "status" },
                values: new object[] { 1, "Prime", 3, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zadanies");
        }
    }
}
