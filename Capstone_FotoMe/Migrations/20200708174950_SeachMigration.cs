using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_FotoMe.Migrations
{
    public partial class SeachMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressesId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressesId",
                table: "Addresses");
        }
    }
}
