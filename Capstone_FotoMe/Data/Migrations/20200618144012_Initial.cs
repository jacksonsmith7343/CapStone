using Microsoft.EntityFrameworkCore.Migrations;


namespace Capstone_FotoMe.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "PhotoEnthusiasts",
                columns: table => new
                {
                    PhotoEnthusiastId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PriceForService = table.Column<int>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    PostRequest = table.Column<string>(nullable: true),
                    Money = table.Column<double>(nullable: false),
                    IdentityUser = table.Column<int>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoEnthusiasts", x => x.PhotoEnthusiastId);
                    table.ForeignKey(
                        name: "FK_PhotoEnthusiasts_Address_IdentityUser",
                        column: x => x.IdentityUser,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoEnthusiasts_IdentityUser",
                table: "PhotoEnthusiasts",
                column: "IdentityUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoEnthusiasts");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
