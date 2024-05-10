using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OmNomBox.API.Migrations
{
    /// <inheritdoc />
    public partial class seededDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492d7b62-42c8-430e-a878-f23b8cbf8f7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2d4684c-5783-4175-85c3-e9bfa4275fda");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9caf4f04-c7f0-469a-9538-f499d8a43220", null, "Administrator", "ADMINISTRATOR" },
                    { "cc3ad5bb-a06d-4d2c-93b1-a8972cdf55e9", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "MachineStatuses",
                columns: new[] { "MachineStatusId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0273be30-d656-406f-9c21-f70f3311349d"), "The machine is in working order and fully operational.", "Operational" },
                    { new Guid("3d3acb44-411c-4b29-94e7-02f273320e47"), "The machine is currently being cleaned.", "Under Cleaning" },
                    { new Guid("48715752-3e1f-4646-aa2b-4bca312e36b6"), "The machine needs to be inspected for safety and compliance.", "Needs Inspection" },
                    { new Guid("7a22dd92-879d-4854-92a0-3cef72465365"), "The machine is out of stock and needs to be restocked.", "Needs Restocking" },
                    { new Guid("d8e256ef-63c8-4ec9-9e5e-7b82a86fe9e4"), "The machine is currently undergoing maintenance.", "Under Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "MachineTypes",
                columns: new[] { "MachineTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("81da0139-729f-4e0b-b942-a91771011388"), "Microwave" },
                    { new Guid("de4f7117-f89c-4c4d-8dcd-81d21013d476"), "Combo Meal" },
                    { new Guid("f0933116-3861-4beb-9ad7-18fd36e8c01a"), "Hot Meal" },
                    { new Guid("fc9b2456-7cb6-4dcf-b2e3-b567fe259d4d"), "Meal Assembly" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { new Guid("81da0139-729f-4e0b-b942-a91771011388"), "Vendo" },
                    { new Guid("de4f7117-f89c-4c4d-8dcd-81d21013d476"), "Royal" },
                    { new Guid("f0933116-3861-4beb-9ad7-18fd36e8c01a"), "Canteen" },
                    { new Guid("fc9b2456-7cb6-4dcf-b2e3-b567fe259d4d"), "Crane" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9caf4f04-c7f0-469a-9538-f499d8a43220");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc3ad5bb-a06d-4d2c-93b1-a8972cdf55e9");

            migrationBuilder.DeleteData(
                table: "MachineStatuses",
                keyColumn: "MachineStatusId",
                keyValue: new Guid("0273be30-d656-406f-9c21-f70f3311349d"));

            migrationBuilder.DeleteData(
                table: "MachineStatuses",
                keyColumn: "MachineStatusId",
                keyValue: new Guid("3d3acb44-411c-4b29-94e7-02f273320e47"));

            migrationBuilder.DeleteData(
                table: "MachineStatuses",
                keyColumn: "MachineStatusId",
                keyValue: new Guid("48715752-3e1f-4646-aa2b-4bca312e36b6"));

            migrationBuilder.DeleteData(
                table: "MachineStatuses",
                keyColumn: "MachineStatusId",
                keyValue: new Guid("7a22dd92-879d-4854-92a0-3cef72465365"));

            migrationBuilder.DeleteData(
                table: "MachineStatuses",
                keyColumn: "MachineStatusId",
                keyValue: new Guid("d8e256ef-63c8-4ec9-9e5e-7b82a86fe9e4"));

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "MachineTypeId",
                keyValue: new Guid("81da0139-729f-4e0b-b942-a91771011388"));

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "MachineTypeId",
                keyValue: new Guid("de4f7117-f89c-4c4d-8dcd-81d21013d476"));

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "MachineTypeId",
                keyValue: new Guid("f0933116-3861-4beb-9ad7-18fd36e8c01a"));

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "MachineTypeId",
                keyValue: new Guid("fc9b2456-7cb6-4dcf-b2e3-b567fe259d4d"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: new Guid("81da0139-729f-4e0b-b942-a91771011388"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: new Guid("de4f7117-f89c-4c4d-8dcd-81d21013d476"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: new Guid("f0933116-3861-4beb-9ad7-18fd36e8c01a"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: new Guid("fc9b2456-7cb6-4dcf-b2e3-b567fe259d4d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "492d7b62-42c8-430e-a878-f23b8cbf8f7c", null, "Customer", "CUSTOMER" },
                    { "e2d4684c-5783-4175-85c3-e9bfa4275fda", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
