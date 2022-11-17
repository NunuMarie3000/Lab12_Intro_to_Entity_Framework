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
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "Coffee", "Fridge", "MiniBar", "OceanView", "PetFriendly", "Safe" },
                values: new object[,]
                {
                    { 51, true, false, true, false, true, true, false },
                    { 52, true, true, true, false, false, false, false },
                    { 53, true, false, true, true, false, true, true }
                });

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
                columns: new[] { "Id", "AssociatedHotel", "IsPetFriendly", "Layout", "Nickname", "Price", "RoomAmenities", "RoomNumber" },
                values: new object[,]
                {
                    { 101, "The Nemo", true, 2, "The Butt", 475, 51, 41 },
                    { 201, "The Green Day", false, 0, "The American Idiot", 255, 52, 20 },
                    { 301, "The Broadway", true, 1, "The Globe", 670, 53, 76 }
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
