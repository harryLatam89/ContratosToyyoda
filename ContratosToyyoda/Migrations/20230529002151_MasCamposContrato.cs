using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratosToyyoda.Migrations
{
    /// <inheritdoc />
    public partial class MasCamposContrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoDoc",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "domicilio",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "estadoFamiliar",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nacionalidad",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numDocId",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profesion",
                table: "Contratos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "sexo",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDoc",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "domicilio",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "estadoFamiliar",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "nacionalidad",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "numDocId",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "profesion",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "sexo",
                table: "Contratos");
        }
    }
}
