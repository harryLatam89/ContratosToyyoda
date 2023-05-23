using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratosToyyoda.Migrations
{
    /// <inheritdoc />
    public partial class agregandoEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nombreUsuario",
                table: "Usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Paises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contratos",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuarios",
                newName: "nombreUsuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Paises",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contratos",
                newName: "id");
        }
    }
}
