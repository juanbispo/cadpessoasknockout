using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadPessoas.Migrations
{
    public partial class AlteracaoNomeNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Pessoas",
                newName: "Nascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nascimento",
                table: "Pessoas",
                newName: "DataNascimento");
        }
    }
}
