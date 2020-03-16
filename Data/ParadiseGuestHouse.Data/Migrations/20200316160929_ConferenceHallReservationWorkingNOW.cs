using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class ConferenceHallReservationWorkingNOW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEvent",
                table: "ConferenceHallReservations");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ConferenceHalls",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "ConferenceHallReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "ConferenceHallReservations");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ConferenceHalls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEvent",
                table: "ConferenceHallReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
