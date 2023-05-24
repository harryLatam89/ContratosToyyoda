using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratosToyyoda.Migrations
{
    /// <inheritdoc />
    public partial class addLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logoUrl",
                table: "Paises");

            migrationBuilder.AddColumn<byte[]>(
                name: "logo",
                table: "Paises",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo",
                table: "Paises");

            migrationBuilder.AddColumn<string>(
                name: "logoUrl",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
