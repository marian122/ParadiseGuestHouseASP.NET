using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Pictures",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
