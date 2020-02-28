using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class conferenceHallModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Reservations_ReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reservations_ReservationId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedRooms_Reservations_ReservationId",
                table: "ReservedRooms");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedRooms",
                table: "ReservedRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservedRooms_ReservationId",
                table: "ReservedRooms");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ReservedRooms");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Guests");

            migrationBuilder.AddColumn<string>(
                name: "RoomReservationId",
                table: "ReservedRooms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConferenceHallId",
                table: "Pictures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConferenceHallReservationId",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomReservationId",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConferenceHallReservationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedRooms",
                table: "ReservedRooms",
                columns: new[] { "RoomId", "RoomReservationId" });

            migrationBuilder.CreateTable(
                name: "ConferenceHallReservations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    DateOfEvent = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    LeaveTime = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceHallReservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceHalls",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    EventType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceHalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    NumberOfNights = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservedConferenceHalls",
                columns: table => new
                {
                    ConferenceHallId = table.Column<string>(nullable: false),
                    ConferenceHallReservationId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedConferenceHalls", x => new { x.ConferenceHallId, x.ConferenceHallReservationId });
                    table.ForeignKey(
                        name: "FK_ReservedConferenceHalls_ConferenceHalls_ConferenceHallId",
                        column: x => x.ConferenceHallId,
                        principalTable: "ConferenceHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservedConferenceHalls_ConferenceHallReservations_ConferenceHallReservationId",
                        column: x => x.ConferenceHallReservationId,
                        principalTable: "ConferenceHallReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservedRooms_RoomReservationId",
                table: "ReservedRooms",
                column: "RoomReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ConferenceHallId",
                table: "Pictures",
                column: "ConferenceHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ConferenceHallReservationId",
                table: "Guests",
                column: "ConferenceHallReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomReservationId",
                table: "Guests",
                column: "RoomReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ConferenceHallReservationId",
                table: "AspNetUsers",
                column: "ConferenceHallReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceHallReservations_IsDeleted",
                table: "ConferenceHallReservations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceHalls_IsDeleted",
                table: "ConferenceHalls",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedConferenceHalls_ConferenceHallReservationId",
                table: "ReservedConferenceHalls",
                column: "ConferenceHallReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedConferenceHalls_IsDeleted",
                table: "ReservedConferenceHalls",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_IsDeleted",
                table: "RoomReservations",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ConferenceHallReservations_ConferenceHallReservationId",
                table: "AspNetUsers",
                column: "ConferenceHallReservationId",
                principalTable: "ConferenceHallReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoomReservations_ReservationId",
                table: "AspNetUsers",
                column: "ReservationId",
                principalTable: "RoomReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_ConferenceHallReservations_ConferenceHallReservationId",
                table: "Guests",
                column: "ConferenceHallReservationId",
                principalTable: "ConferenceHallReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_RoomReservations_RoomReservationId",
                table: "Guests",
                column: "RoomReservationId",
                principalTable: "RoomReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_ConferenceHalls_ConferenceHallId",
                table: "Pictures",
                column: "ConferenceHallId",
                principalTable: "ConferenceHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedRooms_RoomReservations_RoomReservationId",
                table: "ReservedRooms",
                column: "RoomReservationId",
                principalTable: "RoomReservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ConferenceHallReservations_ConferenceHallReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoomReservations_ReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_ConferenceHallReservations_ConferenceHallReservationId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_RoomReservations_RoomReservationId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_ConferenceHalls_ConferenceHallId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedRooms_RoomReservations_RoomReservationId",
                table: "ReservedRooms");

            migrationBuilder.DropTable(
                name: "ReservedConferenceHalls");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.DropTable(
                name: "ConferenceHalls");

            migrationBuilder.DropTable(
                name: "ConferenceHallReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedRooms",
                table: "ReservedRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservedRooms_RoomReservationId",
                table: "ReservedRooms");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_ConferenceHallId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ConferenceHallReservationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_RoomReservationId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ConferenceHallReservationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoomReservationId",
                table: "ReservedRooms");

            migrationBuilder.DropColumn(
                name: "ConferenceHallId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ConferenceHallReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RoomReservationId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ConferenceHallReservationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "ReservedRooms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "Guests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedRooms",
                table: "ReservedRooms",
                columns: new[] { "RoomId", "ReservationId" });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    NumberOfNights = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservedRooms_ReservationId",
                table: "ReservedRooms",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ReservationId",
                table: "Guests",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IsDeleted",
                table: "Reservations",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Reservations_ReservationId",
                table: "AspNetUsers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reservations_ReservationId",
                table: "Guests",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedRooms_Reservations_ReservationId",
                table: "ReservedRooms",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
