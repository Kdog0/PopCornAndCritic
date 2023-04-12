using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasSistemas.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTabelaFilmes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Movies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Movies");
        }
    }
}
