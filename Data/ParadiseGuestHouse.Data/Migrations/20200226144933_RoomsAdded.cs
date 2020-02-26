using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParadiseGuestHouse.Data.Migrations
{
    public partial class RoomsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomDescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RoomType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDescription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Link = table.Column<string>(nullable: false),
                    RoomDescriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_RoomDescription_RoomDescriptionId",
                        column: x => x.RoomDescriptionId,
                        principalTable: "RoomDescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RoomType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureId = table.Column<int>(nullable: true),
                    DescriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomDescription_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "RoomDescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_RoomDescriptionId",
                table: "Pictures",
                column: "RoomDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDescription_IsDeleted",
                table: "RoomDescription",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DescriptionId",
                table: "Rooms",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IsDeleted",
                table: "Rooms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PictureId",
                table: "Rooms",
                column: "PictureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "RoomDescription");
        }
    }
}
