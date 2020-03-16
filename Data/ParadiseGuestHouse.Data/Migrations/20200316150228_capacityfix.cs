using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class capacityfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ConferenceHalls");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "ConferenceHalls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "ConferenceHalls",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "ConferenceHalls");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "ConferenceHalls");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "ConferenceHalls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
