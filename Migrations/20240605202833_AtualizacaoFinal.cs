using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaPessoal.Migrations
{
    public partial class AtualizacaoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nota",
                table: "Livros",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Nota",
                table: "Livros",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
