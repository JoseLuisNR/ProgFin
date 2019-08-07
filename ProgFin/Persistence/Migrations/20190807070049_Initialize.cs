using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEstudiante = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false),
                    Prestamo = table.Column<string>(nullable: true),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    FechaEntregar = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    EstudianteForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Prestamos_EstudianteForeignKey",
                        column: x => x.EstudianteForeignKey,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreLib = table.Column<string>(nullable: true),
                    IdAutor = table.Column<int>(nullable: false),
                    IdTipo = table.Column<int>(nullable: false),
                    PrestamosForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libros_Prestamos_PrestamosForeignKey",
                        column: x => x.PrestamosForeignKey,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreAut = table.Column<string>(nullable: true),
                    ApellidoAut = table.Column<string>(nullable: true),
                    LibrosForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                    table.ForeignKey(
                        name: "FK_Autores_Libros_LibrosForeignKey",
                        column: x => x.LibrosForeignKey,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tipolibros",
                columns: table => new
                {
                    IdTipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(nullable: true),
                    TipolibroForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipolibros", x => x.IdTipo);
                    table.ForeignKey(
                        name: "FK_Tipolibros_Libros_TipolibroForeignKey",
                        column: x => x.TipolibroForeignKey,
                        principalTable: "Libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_LibrosForeignKey",
                table: "Autores",
                column: "LibrosForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_EstudianteForeignKey",
                table: "Estudiantes",
                column: "EstudianteForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_PrestamosForeignKey",
                table: "Libros",
                column: "PrestamosForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Tipolibros_TipolibroForeignKey",
                table: "Tipolibros",
                column: "TipolibroForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Tipolibros");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
