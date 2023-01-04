using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AdicionadoMaisEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "estoques",
                columns: new[] { "Id", "fornecedor_id", "material_id", "quantidade", "tipo", "Valor" },
                values: new object[] { 9, 3, 3, 5, 0, 25.5 });

            migrationBuilder.InsertData(
                table: "estoques",
                columns: new[] { "Id", "fornecedor_id", "material_id", "quantidade", "tipo", "Valor" },
                values: new object[] { 10, 3, 3, 7, 0, 30.100000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
