using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AjustadoSenhaParaHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "Id",
                keyValue: 1,
                column: "senha",
                value: "7110eda4d09e062aa5e4a390b0a572ac0d2c0220");

            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "Id",
                keyValue: 2,
                column: "senha",
                value: "7110eda4d09e062aa5e4a390b0a572ac0d2c0220");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "senha",
                value: "7110eda4d09e062aa5e4a390b0a572ac0d2c0220");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "senha",
                value: "7110eda4d09e062aa5e4a390b0a572ac0d2c0220");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "Id",
                keyValue: 1,
                column: "senha",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "Id",
                keyValue: 2,
                column: "senha",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "senha",
                value: "1234");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "senha",
                value: "1234");
        }
    }
}
