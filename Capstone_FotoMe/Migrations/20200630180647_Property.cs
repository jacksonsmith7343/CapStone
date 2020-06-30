using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone_FotoMe.Migrations
{
    public partial class Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "PhotoEnthusiasts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendFriendRequest",
                table: "PhotoEnthusiasts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "PhotoEnthusiasts");

            migrationBuilder.DropColumn(
                name: "SendFriendRequest",
                table: "PhotoEnthusiasts");
        }
    }
}
