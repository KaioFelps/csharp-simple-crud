using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class RenameEstudantesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "estudantes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "estudantes",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "estudantes",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "estudantes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "estudantes",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "estudantes",
                newName: "Id");
        }
    }
}
