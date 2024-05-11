using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmNomBox.API.Migrations
{
    /// <inheritdoc />
    public partial class addedMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MachineSettings");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "MachineSettings");

            migrationBuilder.AddColumn<Guid>(
                name: "MachineType",
                table: "MachineSettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparationTime = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineSettings_MachineType",
                table: "MachineSettings",
                column: "MachineType");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineSettings_Meals_MachineType",
                table: "MachineSettings",
                column: "MachineType",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_Meals_MachineType",
                table: "MachineSettings");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_MachineSettings_MachineType",
                table: "MachineSettings");

            migrationBuilder.DropColumn(
                name: "MachineType",
                table: "MachineSettings");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MachineSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "MachineSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
