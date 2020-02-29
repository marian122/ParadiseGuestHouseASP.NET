using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class removebasereservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReservedConferenceHallConferenceHallId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReservedConferenceHallConferenceHallReservationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReservedRestaurantRestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReservedRestaurantRestaurantReservationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReservedRoomRoomId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReservedRoomRoomReservationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservedConferenceHalls_ReservedConferenceHallConferenceHallId_ReservedConferenceHallConferenceHallReservationId",
                        columns: x => new { x.ReservedConferenceHallConferenceHallId, x.ReservedConferenceHallConferenceHallReservationId },
                        principalTable: "ReservedConferenceHalls",
                        principalColumns: new[] { "ConferenceHallId", "ConferenceHallReservationId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservedRestaurants_ReservedRestaurantRestaurantId_ReservedRestaurantRestaurantReservationId",
                        columns: x => new { x.ReservedRestaurantRestaurantId, x.ReservedRestaurantRestaurantReservationId },
                        principalTable: "ReservedRestaurants",
                        principalColumns: new[] { "RestaurantId", "RestaurantReservationId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservedRooms_ReservedRoomRoomId_ReservedRoomRoomReservationId",
                        columns: x => new { x.ReservedRoomRoomId, x.ReservedRoomRoomReservationId },
                        principalTable: "ReservedRooms",
                        principalColumns: new[] { "RoomId", "RoomReservationId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IsDeleted",
                table: "Reservations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedConferenceHallConferenceHallId_ReservedConferenceHallConferenceHallReservationId",
                table: "Reservations",
                columns: new[] { "ReservedConferenceHallConferenceHallId", "ReservedConferenceHallConferenceHallReservationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedRestaurantRestaurantId_ReservedRestaurantRestaurantReservationId",
                table: "Reservations",
                columns: new[] { "ReservedRestaurantRestaurantId", "ReservedRestaurantRestaurantReservationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedRoomRoomId_ReservedRoomRoomReservationId",
                table: "Reservations",
                columns: new[] { "ReservedRoomRoomId", "ReservedRoomRoomReservationId" });
        }
    }
}
