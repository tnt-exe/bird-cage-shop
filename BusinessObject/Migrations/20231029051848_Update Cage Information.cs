using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class UpdateCageInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CageSize",
                table: "Cage",
                newName: "Radius");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Cage",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Cage");

            migrationBuilder.RenameColumn(
                name: "Radius",
                table: "Cage",
                newName: "CageSize");
        }
    }
}
