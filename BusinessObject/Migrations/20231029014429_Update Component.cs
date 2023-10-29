using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class UpdateComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Component");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Component");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CageComponent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "CageComponent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CageComponent");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "CageComponent");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Component",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Component",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
