using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OmNomBox.API.Migrations
{
    /// <inheritdoc />
    public partial class editedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_Machines_MachineId",
                table: "MachineSettings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb5c580-f8a8-4368-a43d-830b15ea9f01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d97c8d-0a3f-4346-8aa3-94c80b73c78c");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "MachineSettings",
                newName: "MachineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineSettings_MachineId",
                table: "MachineSettings",
                newName: "IX_MachineSettings_MachineTypeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "492d7b62-42c8-430e-a878-f23b8cbf8f7c", null, "Customer", "CUSTOMER" },
                    { "e2d4684c-5783-4175-85c3-e9bfa4275fda", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0f4c011c-a92f-42de-8343-165fc07926d6"), "3500 Deer Creek Road, Palo Alto, CA 94304", "YummyBox", null },
                    { new Guid("77a0c320-00c6-413e-af46-304db9ddff7b"), "5550 Olphan Street, Montgomery, CA 94890", "TastyMachines", null }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "MealId", "Description", "Name", "PreparationTime", "Price" },
                values: new object[,]
                {
                    { new Guid("b841ccd2-b246-4350-b756-a369d0556be4"), "Indulge in succulent chicken breast, delicately seasoned a crispy golden coating.", "Savory Herb-Crusted Chicken", 0.0, 12.99 },
                    { new Guid("b841ccd2-b246-4350-b785-a369d0556bd4"), "A healthy bowl of oatmeal with fruit and nuts.", "Oatmeal", 0.0, 3.9900000000000002 },
                    { new Guid("fa881d8b-83a2-47b3-9d1d-15d1066d8987"), "Delight your senses with layers of tropical fruits, creamy Greek yogurt, and homemade granola.", "Exotic Fruit Parfait", 0.0, 7.9900000000000002 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MachineSettings_MachineTypes_MachineTypeId",
                table: "MachineSettings",
                column: "MachineTypeId",
                principalTable: "MachineTypes",
                principalColumn: "MachineTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_MachineTypes_MachineTypeId",
                table: "MachineSettings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492d7b62-42c8-430e-a878-f23b8cbf8f7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2d4684c-5783-4175-85c3-e9bfa4275fda");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("0f4c011c-a92f-42de-8343-165fc07926d6"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("77a0c320-00c6-413e-af46-304db9ddff7b"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "MealId",
                keyValue: new Guid("b841ccd2-b246-4350-b756-a369d0556be4"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "MealId",
                keyValue: new Guid("b841ccd2-b246-4350-b785-a369d0556bd4"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "MealId",
                keyValue: new Guid("fa881d8b-83a2-47b3-9d1d-15d1066d8987"));

            migrationBuilder.RenameColumn(
                name: "MachineTypeId",
                table: "MachineSettings",
                newName: "MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineSettings_MachineTypeId",
                table: "MachineSettings",
                newName: "IX_MachineSettings_MachineId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5cb5c580-f8a8-4368-a43d-830b15ea9f01", null, "Customer", "CUSTOMER" },
                    { "78d97c8d-0a3f-4346-8aa3-94c80b73c78c", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MachineSettings_Machines_MachineId",
                table: "MachineSettings",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
