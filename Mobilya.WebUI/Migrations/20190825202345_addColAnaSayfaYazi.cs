using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobilya.WebUI.Migrations
{
    public partial class addColAnaSayfaYazi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnaSayfaYazi",
                table: "Dukkan",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnaSayfaYazi",
                table: "Dukkan");
        }
    }
}
