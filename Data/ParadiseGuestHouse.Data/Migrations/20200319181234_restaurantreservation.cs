using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class restaurantreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReservations_AspNetUsers_ApplicationUserId",
                table: "RestaurantReservations");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantReservations_ApplicationUserId",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "RestaurantReservations");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCapacity",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "RestaurantReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "RestaurantReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "RestaurantReservations",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "RestaurantReservations",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RestaurantReservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantReservations_UserId",
                table: "RestaurantReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReservations_AspNetUsers_UserId",
                table: "RestaurantReservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReservations_AspNetUsers_UserId",
                table: "RestaurantReservations");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantReservations_UserId",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "CurrentCapacity",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RestaurantReservations");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RestaurantReservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "RestaurantReservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantReservations_ApplicationUserId",
                table: "RestaurantReservations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReservations_AspNetUsers_ApplicationUserId",
                table: "RestaurantReservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
