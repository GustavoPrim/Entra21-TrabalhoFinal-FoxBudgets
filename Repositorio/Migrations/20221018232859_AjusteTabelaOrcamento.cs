using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AjusteTabelaOrcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_materiais_MaterialId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Orcamento_OrcamentoId",
                table: "Orcamentos");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_MaterialId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Orcamentos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Orcamentos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "OrcamentoId",
                table: "Orcamentos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_OrcamentoId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_ClienteId");

            migrationBuilder.CreateTable(
                name: "orcamentos_materiais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<int>(type: "int", nullable: false),
                    orcamento_id = table.Column<int>(type: "INT", nullable: false),
                    material_id = table.Column<int>(type: "INT", nullable: false),
                    quantidade_id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orcamentos_materiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orcamentos_materiais_materiais_material_id",
                        column: x => x.material_id,
                        principalTable: "materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orcamentos_materiais_Orcamentos_orcamento_id",
                        column: x => x.orcamento_id,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_materiais_material_id",
                table: "orcamentos_materiais",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_materiais_orcamento_id",
                table: "orcamentos_materiais",
                column: "orcamento_id");

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
                name: "FK_Orcamentos_clientes_ClienteId",
                table: "Orcamentos");

            migrationBuilder.DropTable(
                name: "orcamentos_materiais");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Orcamentos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Orcamentos",
                newName: "OrcamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_OrcamentoId");

            migrationBuilder.AddColumn<int>(
                name: "Item",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataOrcamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotalItem = table.Column<double>(type: "float", nullable: false),
                    ValorTotalOrcamento = table.Column<double>(type: "float", nullable: false),
                    ValorUnitarioItem = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamento_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_MaterialId",
                table: "Orcamentos",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_ClienteId",
                table: "Orcamento",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_materiais_MaterialId",
                table: "Orcamentos",
                column: "MaterialId",
                principalTable: "materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Orcamento_OrcamentoId",
                table: "Orcamentos",
                column: "OrcamentoId",
                principalTable: "Orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
