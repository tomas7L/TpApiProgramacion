using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinariaApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duenios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duenios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAnimales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAnimales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAnimalId = table.Column<int>(type: "int", nullable: false),
                    DuenioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animales_Duenios_DuenioId",
                        column: x => x.DuenioId,
                        principalTable: "Duenios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animales_TiposAnimales_TipoAnimalId",
                        column: x => x.TipoAnimalId,
                        principalTable: "TiposAnimales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Razas_TiposAnimales_TipoAnimalId",
                        column: x => x.TipoAnimalId,
                        principalTable: "TiposAnimales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamientos_Animales_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    TratamientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atenciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atenciones_Animales_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atenciones_Tratamientos_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "Tratamientos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animales_DuenioId",
                table: "Animales",
                column: "DuenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Animales_TipoAnimalId",
                table: "Animales",
                column: "TipoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_AnimalId",
                table: "Atenciones",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_TratamientoId",
                table: "Atenciones",
                column: "TratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_TipoAnimalId",
                table: "Razas",
                column: "TipoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_AnimalId",
                table: "Tratamientos",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "Animales");

            migrationBuilder.DropTable(
                name: "Duenios");

            migrationBuilder.DropTable(
                name: "TiposAnimales");
        }
    }
}
