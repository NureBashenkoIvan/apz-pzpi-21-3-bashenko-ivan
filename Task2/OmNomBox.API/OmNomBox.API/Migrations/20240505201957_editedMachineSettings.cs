using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmNomBox.API.Migrations
{
    /// <inheritdoc />
    public partial class editedMachineSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_Meals_MachineTypeId",
                table: "MachineSettings");

            migrationBuilder.RenameColumn(
                name: "MachineTypeId",
                table: "MachineSettings",
                newName: "MealId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineSettings_MachineTypeId",
                table: "MachineSettings",
                newName: "IX_MachineSettings_MealId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CompanyId",
                table: "Order",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MachineId",
                table: "Order",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MealId",
                table: "Order",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineSettings_Meals_MealId",
                table: "MachineSettings",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_Meals_MealId",
                table: "MachineSettings");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "MachineSettings",
                newName: "MachineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineSettings_MealId",
                table: "MachineSettings",
                newName: "IX_MachineSettings_MachineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineSettings_Meals_MachineTypeId",
                table: "MachineSettings",
                column: "MachineTypeId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
