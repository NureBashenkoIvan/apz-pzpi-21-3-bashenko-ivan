using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmNomBox.API.Migrations
{
    /// <inheritdoc />
    public partial class editedMealsType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_Meals_MachineType",
                table: "MachineSettings");

            migrationBuilder.RenameColumn(
                name: "MachineType",
                table: "MachineSettings",
                newName: "MachineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineSettings_MachineType",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineSettings_Meals_MachineTypeId",
                table: "MachineSettings");

            migrationBuilder.RenameColumn(
                name: "MachineTypeId",
                table: "MachineSettings",
                newName: "MachineType");

            migrationBuilder.RenameIndex(
                name: "IX_MachineSettings_MachineTypeId",
                table: "MachineSettings",
                newName: "IX_MachineSettings_MachineType");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineSettings_Meals_MachineType",
                table: "MachineSettings",
                column: "MachineType",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
