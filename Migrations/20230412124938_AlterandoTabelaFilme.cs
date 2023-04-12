using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasSistemas.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTabelaFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TarefasLista",
                table: "TarefasLista");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TarefasLista");

            migrationBuilder.RenameTable(
                name: "TarefasLista",
                newName: "Movies");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "Title");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "TarefasLista");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TarefasLista",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TarefasLista",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarefasLista",
                table: "TarefasLista",
                column: "Id");
        }
    }
}
