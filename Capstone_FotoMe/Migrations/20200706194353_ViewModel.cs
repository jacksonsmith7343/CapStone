using Microsoft.EntityFrameworkCore.Migrations;



namespace Capstone_FotoMe.Migrations
{
    public partial class ViewModel : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PhotoEnthusiasts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PhotoEnthusiasts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PhotoEnthusiasts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PhotoEnthusiasts");
        }
    }
}
