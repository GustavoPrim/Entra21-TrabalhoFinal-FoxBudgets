using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AddCpfEntidadeMapeamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "fornecedores",
                type: "VARCHAR(18)",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "fornecedores",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "cnpj",
                value: "34.568.789/0001-25");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "cnpj", "cpf" },
                values: new object[] { null, "089.567.453-87" });

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "cnpj", "cpf" },
                values: new object[] { null, "567.453.676-99" });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_EstoqueId",
                table: "Estoque",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Estoque_EstoqueId",
                table: "Estoque",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Estoque_EstoqueId",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_EstoqueId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "fornecedores");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Estoque");

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "fornecedores",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(18)",
                oldMaxLength: 18,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "cnpj",
                value: "34.56.789/0001-25");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "cnpj",
                value: "12.123.456/0001-78");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 4,
                column: "cnpj",
                value: "23.756.976/0001-65");
        }
    }
}
