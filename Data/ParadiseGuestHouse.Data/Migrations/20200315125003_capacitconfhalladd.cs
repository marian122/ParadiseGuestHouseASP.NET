using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class capacitconfhalladd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ConferenceHallReservations_ConferenceHallReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantReservations_RestaurantReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ConferenceHallReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "ConferenceHallReservations");

            migrationBuilder.DropColumn(
                name: "LeaveTime",
                table: "ConferenceHallReservations");

            migrationBuilder.DropColumn(
                name: "ConferenceHallReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantReservationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RestaurantReservations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "ConferenceHalls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "ConferenceHallReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "ConferenceHallReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ConferenceHallReservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ConferenceHallReservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantReservations_ApplicationUserId",
                table: "RestaurantReservations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceHallReservations_UserId",
                table: "ConferenceHallReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceHallReservations_AspNetUsers_UserId",
                table: "ConferenceHallReservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReservations_AspNetUsers_ApplicationUserId",
                table: "RestaurantReservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceHallReservations_AspNetUsers_UserId",
                table: "ConferenceHallReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReservations_AspNetUsers_ApplicationUserId",
                table: "RestaurantReservations");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantReservations_ApplicationUserId",
                table: "RestaurantReservations");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceHallReservations_UserId",
                table: "ConferenceHallReservations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ConferenceHalls");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "ConferenceHallReservations");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "ConferenceHallReservations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ConferenceHallReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ConferenceHallReservations");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "ConferenceHallReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LeaveTime",
                table: "ConferenceHallReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ConferenceHallReservationId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantReservationId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ConferenceHallReservationId",
                table: "AspNetUsers",
                column: "ConferenceHallReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantReservationId",
                table: "AspNetUsers",
                column: "RestaurantReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ConferenceHallReservations_ConferenceHallReservationId",
                table: "AspNetUsers",
                column: "ConferenceHallReservationId",
                principalTable: "ConferenceHallReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantReservations_RestaurantReservationId",
                table: "AspNetUsers",
                column: "RestaurantReservationId",
                principalTable: "RestaurantReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
