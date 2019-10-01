using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobilya.WebUI.Migrations
{
    public partial class addDukkan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dukkan",
                columns: table => new
                {
                    DukkanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Telefon = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Hakkimizda = table.Column<string>(nullable: true),
                    OzelIstek = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dukkan", x => x.DukkanId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dukkan");
        }
    }
}
