using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDataInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BoardingType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Full Board" },
                    { 2, "Half Board" },
                    { 3, "Breakfast only" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedOn", "Email", "MobileNumber", "Name", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("a38322c7-79eb-409c-8d8d-08dcc87d6780"), new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8404), "Sara@gmail.com", "01235441987", "Sara", new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8404) },
                    { new Guid("a38322c7-79eb-409c-8f8c-08dcc87d6780"), new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8400), "Ali@gmail.com", "0123546987", "Ali", new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8401) }
                });

            migrationBuilder.InsertData(
                table: "ReservationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "UpComing" },
                    { 2, "Active" },
                    { 3, "Past" },
                    { 4, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "RoomSpacifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pool view" },
                    { 2, "See View" },
                    { 3, "Air conditioning" },
                    { 4, "TV" },
                    { 5, "WiFi" },
                    { 6, "electric Kettle" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Deluxe" },
                    { 2, "Single" },
                    { 3, "Double" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "AdultNo", "ChildNo", "FloorNumber", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1L, 2, 1, 1, 1001, 1 },
                    { 2L, 1, 0, 2, 2002, 2 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypeSpacifications",
                columns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BoardingTypeId", "CreatedOn", "CustomerId", "EndDate", "ReferenceNumber", "ReservationStatusId", "RoomId", "StartDate", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, 1, new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8441), new Guid("a38322c7-79eb-409c-8f8c-08dcc87d6780"), new DateTime(2024, 9, 14, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8426), "RS1050924", 1, 1L, new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8425), new DateTime(2024, 8, 30, 22, 39, 34, 411, DateTimeKind.Utc).AddTicks(8442) },
                    { 2L, 2, new DateTime(2024, 8, 29, 14, 30, 0, 0, DateTimeKind.Unspecified), new Guid("a38322c7-79eb-409c-8d8d-08dcc87d6780"), new DateTime(2024, 9, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), "RS2300824", 2, 2L, new DateTime(2024, 8, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 29, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardingType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ReservationStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservationStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RoomTypeSpacifications",
                keyColumns: new[] { "RoomSpacificationsId", "RoomTypeId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "BoardingType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BoardingType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("a38322c7-79eb-409c-8d8d-08dcc87d6780"));

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("a38322c7-79eb-409c-8f8c-08dcc87d6780"));

            migrationBuilder.DeleteData(
                table: "ReservationStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservationStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RoomSpacifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomSpacifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomSpacifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomSpacifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomSpacifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomSpacifications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
