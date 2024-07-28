using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class RenameEstudantesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudantes",
                table: "Estudantes");

            migrationBuilder.RenameTable(
                name: "Estudantes",
                newName: "estudantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estudantes",
                table: "estudantes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_estudantes",
                table: "estudantes");

            migrationBuilder.RenameTable(
                name: "estudantes",
                newName: "Estudantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudantes",
                table: "Estudantes",
                column: "Id");
        }
    }
}
