using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AdicionarTabelaOrcamentoMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoMaterial_materiais_MaterialId",
                table: "OrcamentoMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_OrcamentoMaterial_Orcamentos_OrcamentoId",
                table: "OrcamentoMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrcamentoMaterial",
                table: "OrcamentoMaterial");

            migrationBuilder.RenameTable(
                name: "OrcamentoMaterial",
                newName: "orcamentos_materiais");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "orcamentos_materiais",
                newName: "quantidade_id");

            migrationBuilder.RenameColumn(
                name: "OrcamentoId",
                table: "orcamentos_materiais",
                newName: "orcamento_id");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "orcamentos_materiais",
                newName: "material_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrcamentoMaterial_OrcamentoId",
                table: "orcamentos_materiais",
                newName: "IX_orcamentos_materiais_orcamento_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrcamentoMaterial_MaterialId",
                table: "orcamentos_materiais",
                newName: "IX_orcamentos_materiais_material_id");

            migrationBuilder.AlterColumn<int>(
                name: "quantidade_id",
                table: "orcamentos_materiais",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "orcamento_id",
                table: "orcamentos_materiais",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "material_id",
                table: "orcamentos_materiais",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orcamentos_materiais",
                table: "orcamentos_materiais",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_materiais_materiais_material_id",
                table: "orcamentos_materiais",
                column: "material_id",
                principalTable: "materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_materiais_Orcamentos_orcamento_id",
                table: "orcamentos_materiais",
                column: "orcamento_id",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_materiais_materiais_material_id",
                table: "orcamentos_materiais");

            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_materiais_Orcamentos_orcamento_id",
                table: "orcamentos_materiais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orcamentos_materiais",
                table: "orcamentos_materiais");

            migrationBuilder.RenameTable(
                name: "orcamentos_materiais",
                newName: "OrcamentoMaterial");

            migrationBuilder.RenameColumn(
                name: "quantidade_id",
                table: "OrcamentoMaterial",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "orcamento_id",
                table: "OrcamentoMaterial",
                newName: "OrcamentoId");

            migrationBuilder.RenameColumn(
                name: "material_id",
                table: "OrcamentoMaterial",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_orcamentos_materiais_orcamento_id",
                table: "OrcamentoMaterial",
                newName: "IX_OrcamentoMaterial_OrcamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_orcamentos_materiais_material_id",
                table: "OrcamentoMaterial",
                newName: "IX_OrcamentoMaterial_MaterialId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "OrcamentoMaterial",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "OrcamentoId",
                table: "OrcamentoMaterial",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "OrcamentoMaterial",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrcamentoMaterial",
                table: "OrcamentoMaterial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrcamentoMaterial_materiais_MaterialId",
                table: "OrcamentoMaterial",
                column: "MaterialId",
                principalTable: "materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrcamentoMaterial_Orcamentos_OrcamentoId",
                table: "OrcamentoMaterial",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
