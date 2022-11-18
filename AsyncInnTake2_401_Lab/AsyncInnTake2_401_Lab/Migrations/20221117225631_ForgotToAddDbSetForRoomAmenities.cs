using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncInnTake2401Lab.Migrations
{
    /// <inheritdoc />
    public partial class ForgotToAddDbSetForRoomAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesId",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.RenameTable(
                name: "RoomAmenities",
                newName: "RoomAmenitieses");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomId",
                table: "RoomAmenitieses",
                newName: "IX_RoomAmenitieses_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_AmenitiesId",
                table: "RoomAmenitieses",
                newName: "IX_RoomAmenitieses_AmenitiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenitieses",
                table: "RoomAmenitieses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenitieses_Amenities_AmenitiesId",
                table: "RoomAmenitieses",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenitieses_Rooms_RoomId",
                table: "RoomAmenitieses",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenitieses_Amenities_AmenitiesId",
                table: "RoomAmenitieses");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenitieses_Rooms_RoomId",
                table: "RoomAmenitieses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenitieses",
                table: "RoomAmenitieses");

            migrationBuilder.RenameTable(
                name: "RoomAmenitieses",
                newName: "RoomAmenities");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenitieses_RoomId",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenitieses_AmenitiesId",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_AmenitiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesId",
                table: "RoomAmenities",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
