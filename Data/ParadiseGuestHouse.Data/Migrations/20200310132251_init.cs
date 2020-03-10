using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_AspNetUsers_ApplicationUserId",
                table: "RoomReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomReservations_ApplicationUserId",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "RoomReservations");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoomReservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_UserId",
                table: "RoomReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_AspNetUsers_UserId",
                table: "RoomReservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_AspNetUsers_UserId",
                table: "RoomReservations");

            migrationBuilder.DropIndex(
                name: "IX_RoomReservations_UserId",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoomReservations");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "RoomReservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_ApplicationUserId",
                table: "RoomReservations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_AspNetUsers_ApplicationUserId",
                table: "RoomReservations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
