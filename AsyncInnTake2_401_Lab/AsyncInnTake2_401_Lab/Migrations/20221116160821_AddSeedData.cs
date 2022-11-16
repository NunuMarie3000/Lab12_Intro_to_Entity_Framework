using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInnTake2401Lab.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "NumberOfRooms", "PhoneNumber", "State" },
                values: new object[,]
                {
                    { 100, "P.Sherman 42 Wallaby Way", "Sydney", "The Nemo", 42, "555-555-5555", "Australia" },
                    { 200, "321 Broken Dreams Boulevard", "Greenday", "The Green Day", 21, "867-5309", "Ohio" },
                    { 300, "123 Hollywood Drive", "Hollywood", "The Broadway", 77, "911-911-9111", "Iowa" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "IsPetFriendly", "Layout", "Nickname", "Price", "RoomNumber" },
                values: new object[,]
                {
                    { 101, 100, true, 2, "The Butt", 475, 41 },
                    { 201, 200, false, 0, "The American Idiot", 255, 20 },
                    { 301, 300, true, 1, "The Globe", 670, 76 }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "Coffee", "Fridge", "MiniBar", "OceanView", "PetFriendly", "RoomId", "Safe" },
                values: new object[,]
                {
                    { 51, true, false, true, false, true, true, 101, false },
                    { 52, true, true, true, false, false, false, 201, false },
                    { 53, true, false, true, true, false, true, 301, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 301);
        }
    }
}
