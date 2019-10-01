using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobilya.WebUI.Migrations
{
    public partial class addDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrunImage_Urunler_UrunId",
                table: "UrunImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrunImage",
                table: "UrunImage");

            migrationBuilder.RenameTable(
                name: "UrunImage",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_UrunImage_UrunId",
                table: "Images",
                newName: "IX_Images_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "UrunImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Urunler_UrunId",
                table: "Images",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Urunler_UrunId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "UrunImage");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UrunId",
                table: "UrunImage",
                newName: "IX_UrunImage_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrunImage",
                table: "UrunImage",
                column: "UrunImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrunImage_Urunler_UrunId",
                table: "UrunImage",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
