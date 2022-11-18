using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInnTake2401Lab.Migrations
{
    /// <inheritdoc />
    public partial class ReSeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomAmenitieses",
                columns: new[] { "Id", "AmenitiesId", "RoomId" },
                values: new object[,]
                {
                    { 751, 52, 201 },
                    { 752, 53, 301 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomAmenitieses",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "RoomAmenitieses",
                keyColumn: "Id",
                keyValue: 752);
        }
    }
}
