using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AjustePermitirCpfCnpjNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamento_clientes_ClienteId",
                table: "Orcamento");

            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoMaterial_Orcamento_OrcamentoId",
                table: "OrcamentoMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orcamento",
                table: "Orcamento");

            migrationBuilder.RenameTable(
                name: "Orcamento",
                newName: "Orcamentos");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "clientes",
                newName: "login");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamento_ClienteId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(18)",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "clientes",
                type: "VARCHAR(18)",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(18)",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "login",
                table: "clientes",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataOrcamento",
                table: "Orcamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Orcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalItem",
                table: "Orcamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalOrcamento",
                table: "Orcamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorUnitarioItem",
                table: "Orcamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos",
                column: "Id");

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
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "login",
                value: "gui");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "login",
                value: "ju");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "cnpj", "senha" },
                values: new object[] { "34.56.789/0001-25", "1234" });

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "cnpj", "senha" },
                values: new object[] { "12.123.456/0001-78", "1234" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrcamentoMaterial_Orcamentos_OrcamentoId",
                table: "OrcamentoMaterial",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_clientes_ClienteId",
                table: "Orcamentos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoMaterial_Orcamentos_OrcamentoId",
                table: "OrcamentoMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_clientes_ClienteId",
                table: "Orcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "DataOrcamento",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "ValorTotalItem",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "ValorTotalOrcamento",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "ValorUnitarioItem",
                table: "Orcamentos");

            migrationBuilder.RenameTable(
                name: "Orcamentos",
                newName: "Orcamento");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "clientes",
                newName: "Login");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamento",
                newName: "IX_Orcamento_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "VARCHAR(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "clientes",
                type: "VARCHAR(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(18)",
                oldMaxLength: 18,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orcamento",
                table: "Orcamento",
                column: "Id");

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
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Login",
                value: "d6a7af134530254f6dae4886d160be8e6c6891c9");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Login",
                value: "a7ae639ea556171c56cd06c61c2cfd09ccbee0a9");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "cnpj", "senha" },
                values: new object[] { "", "7110eda4d09e062aa5e4a390b0a572ac0d2c0220" });

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "cnpj", "senha" },
                values: new object[] { "", "7110eda4d09e062aa5e4a390b0a572ac0d2c0220" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamento_clientes_ClienteId",
                table: "Orcamento",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrcamentoMaterial_Orcamento_OrcamentoId",
                table: "OrcamentoMaterial",
                column: "OrcamentoId",
                principalTable: "Orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
