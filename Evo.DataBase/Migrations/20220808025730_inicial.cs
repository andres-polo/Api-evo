using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evo.DataBase.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Empresas");

            migrationBuilder.CreateTable(
                name: "Propietarios",
                schema: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMascotas",
                schema: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMascotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mascotas",
                schema: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    TipoDeMascotaId = table.Column<int>(type: "int", nullable: false),
                    PropietarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mascotas_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalSchema: "Empresas",
                        principalTable: "Propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mascotas_TipoMascotas_TipoDeMascotaId",
                        column: x => x.TipoDeMascotaId,
                        principalSchema: "Empresas",
                        principalTable: "TipoMascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_PropietarioId",
                schema: "Empresas",
                table: "mascotas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_TipoDeMascotaId",
                schema: "Empresas",
                table: "mascotas",
                column: "TipoDeMascotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mascotas",
                schema: "Empresas");

            migrationBuilder.DropTable(
                name: "Propietarios",
                schema: "Empresas");

            migrationBuilder.DropTable(
                name: "TipoMascotas",
                schema: "Empresas");
        }
    }
}
