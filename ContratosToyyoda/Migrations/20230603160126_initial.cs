using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratosToyyoda.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idApoderado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sexo = table.Column<int>(type: "int", nullable: false),
                    estadoFamiliar = table.Column<int>(type: "int", nullable: false),
                    profesion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numDocId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sueldo = table.Column<double>(type: "float", nullable: true),
                    tipoContrato = table.Column<int>(type: "int", nullable: true),
                    fechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaEmision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inactivo = table.Column<bool>(type: "bit", nullable: true),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idPais = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Paises_idPais",
                        column: x => x.idPais,
                        principalTable: "Paises",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personas_Usuarios_idUser",
                        column: x => x.idUser,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paises_idApoderado",
                table: "Paises",
                column: "idApoderado");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_email",
                table: "Personas",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_idPais",
                table: "Personas",
                column: "idPais");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_idUser",
                table: "Personas",
                column: "idUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Personas_idApoderado",
                table: "Paises",
                column: "idApoderado",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Personas_idApoderado",
                table: "Paises");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
