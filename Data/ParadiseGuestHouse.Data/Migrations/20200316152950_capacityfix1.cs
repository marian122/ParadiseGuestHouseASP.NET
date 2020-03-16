using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class capacityfix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfHallType",
                table: "ConferenceHalls");

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "ConferenceHalls",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventType",
                table: "ConferenceHallReservations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventType",
                table: "ConferenceHalls");

            migrationBuilder.AddColumn<int>(
                name: "ConfHallType",
                table: "ConferenceHalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EventType",
                table: "ConferenceHallReservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
