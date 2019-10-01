using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobilya.WebUI.Migrations
{
    public partial class urunColAddAciklamaAndGozukmeSayisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Urunler",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GozukmeSayisi",
                table: "Urunler",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "GozukmeSayisi",
                table: "Urunler");
        }
    }
}
