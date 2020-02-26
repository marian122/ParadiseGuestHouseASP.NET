using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class modelrenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomDescription_DescriptionId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_DescriptionId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "RoomDescriptionId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomDescriptionId",
                table: "Rooms",
                column: "RoomDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomDescription_RoomDescriptionId",
                table: "Rooms",
                column: "RoomDescriptionId",
                principalTable: "RoomDescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomDescription_RoomDescriptionId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomDescriptionId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomDescriptionId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DescriptionId",
                table: "Rooms",
                column: "DescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomDescription_DescriptionId",
                table: "Rooms",
                column: "DescriptionId",
                principalTable: "RoomDescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
