using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class addsomethings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoomReservations_RoomReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoomReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoomReservationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "RoomReservations",
                nullable: false,
                defaultValue: 0m);

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
                name: "TotalPrice",
                table: "RoomReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoomReservations");

            migrationBuilder.AddColumn<string>(
                name: "RoomReservationId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoomReservationId",
                table: "AspNetUsers",
                column: "RoomReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoomReservations_RoomReservationId",
                table: "AspNetUsers",
                column: "RoomReservationId",
                principalTable: "RoomReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
