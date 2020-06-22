using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_FotoMe.Data.Migrations
{
    public partial class Primarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoEnthusiasts_Address_IdentityUser",
                table: "PhotoEnthusiasts");

            migrationBuilder.DropIndex(
                name: "IX_PhotoEnthusiasts_IdentityUser",
                table: "PhotoEnthusiasts");

            migrationBuilder.DropColumn(
                name: "IdentityUser",
                table: "PhotoEnthusiasts");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoEnthusiasts_AddressId",
                table: "PhotoEnthusiasts",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoEnthusiasts_Address_AddressId",
                table: "PhotoEnthusiasts",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoEnthusiasts_Address_AddressId",
                table: "PhotoEnthusiasts");

            migrationBuilder.DropIndex(
                name: "IX_PhotoEnthusiasts_AddressId",
                table: "PhotoEnthusiasts");

            migrationBuilder.AddColumn<int>(
                name: "IdentityUser",
                table: "PhotoEnthusiasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoEnthusiasts_IdentityUser",
                table: "PhotoEnthusiasts",
                column: "IdentityUser");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoEnthusiasts_Address_IdentityUser",
                table: "PhotoEnthusiasts",
                column: "IdentityUser",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
