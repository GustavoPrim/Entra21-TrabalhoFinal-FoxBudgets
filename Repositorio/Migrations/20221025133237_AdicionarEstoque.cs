using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AdicionarEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Estoque_EstoqueId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_fornecedores_FornecedorId",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_materiais_MaterialId",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_EstoqueId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Estoque");

            migrationBuilder.RenameTable(
                name: "Estoque",
                newName: "estoques");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "estoques",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "estoques",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "estoques",
                newName: "material_id");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "estoques",
                newName: "fornecedor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_MaterialId",
                table: "estoques",
                newName: "IX_estoques_material_id");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_FornecedorId",
                table: "estoques",
                newName: "IX_estoques_fornecedor_id");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tipo",
                table: "estoques",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "estoques",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "material_id",
                table: "estoques",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fornecedor_id",
                table: "estoques",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estoques",
                table: "estoques",
                column: "Id");

            migrationBuilder.InsertData(
                table: "estoques",
                columns: new[] { "Id", "fornecedor_id", "material_id", "quantidade", "tipo", "Valor" },
                values: new object[,]
                {
                    { 1, 3, 3, 2, 0, 23.5 },
                    { 2, 4, 6, 6, 1, 67.900000000000006 },
                    { 3, 2, 10, 8, 1, 50.0 },
                    { 4, 1, 6, 10, 0, 99.989999999999995 },
                    { 5, 1, 2, 7, 1, 76.560000000000002 },
                    { 6, 2, 4, 19, 0, 95.340000000000003 },
                    { 7, 3, 5, 50, 1, 100.0 },
                    { 8, 4, 2, 75, 0, 150.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_estoques_fornecedores_fornecedor_id",
                table: "estoques",
                column: "fornecedor_id",
                principalTable: "fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_estoques_materiais_material_id",
                table: "estoques",
                column: "material_id",
                principalTable: "materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_estoques_fornecedores_fornecedor_id",
                table: "estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_estoques_materiais_material_id",
                table: "estoques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estoques",
                table: "estoques");

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "estoques",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.RenameTable(
                name: "estoques",
                newName: "Estoque");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Estoque",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Estoque",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "material_id",
                table: "Estoque",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "fornecedor_id",
                table: "Estoque",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_estoques_material_id",
                table: "Estoque",
                newName: "IX_Estoque_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_estoques_fornecedor_id",
                table: "Estoque",
                newName: "IX_Estoque_FornecedorId");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "VARCHAR(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Estoque",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Estoque",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Estoque",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "FornecedorId",
                table: "Estoque",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_fornecedores_FornecedorId",
                table: "Estoque",
                column: "FornecedorId",
                principalTable: "fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_materiais_MaterialId",
                table: "Estoque",
                column: "MaterialId",
                principalTable: "materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
