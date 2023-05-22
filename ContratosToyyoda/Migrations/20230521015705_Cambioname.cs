using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratosToyyoda.Migrations
{
    /// <inheritdoc />
    public partial class Cambioname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "AspNetUsers",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "NombreCompleto");
        }
    }
}
