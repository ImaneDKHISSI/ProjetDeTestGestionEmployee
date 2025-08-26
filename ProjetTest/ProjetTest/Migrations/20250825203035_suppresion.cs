using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetTest.Migrations
{
    /// <inheritdoc />
    public partial class suppresion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
