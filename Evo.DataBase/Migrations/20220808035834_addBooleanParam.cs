using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evo.DataBase.Migrations
{
    public partial class addBooleanParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Empresas",
                table: "mascotas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Empresas",
                table: "mascotas");
        }
    }
}
