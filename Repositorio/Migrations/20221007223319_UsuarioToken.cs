using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class UsuarioToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_clientes_ClienteId",
                table: "Orcamentos");

            migrationBuilder.DropTable(
                name: "OrcamentoMaterial");

            migrationBuilder.DropColumn(
                name: "DataOrcamento",
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

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Orcamentos",
                newName: "OrcamentoId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Orcamentos",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_ClienteId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_MaterialId");

            migrationBuilder.AlterColumn<int>(
                name: "Item",
                table: "Orcamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Estoque",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInspiracaoToken",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmado",
                table: "clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Token",
                table: "clientes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    DataOrcamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitarioItem = table.Column<double>(type: "float", nullable: false),
                    ValorTotalItem = table.Column<double>(type: "float", nullable: false),
                    ValorTotalOrcamento = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Orcamentos_OrcamentoId",
                table: "Orcamentos",
                column: "OrcamentoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_Orcamentos_OrcamentoId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "DataInspiracaoToken",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "EmailConfirmado",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "clientes");

            migrationBuilder.RenameColumn(
                name: "OrcamentoId",
                table: "Orcamentos",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Orcamentos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Orcamentos_MaterialId",
                table: "Orcamentos",
                newName: "IX_Orcamentos_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Item",
                table: "Orcamentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataOrcamento",
                table: "Orcamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.CreateTable(
                name: "OrcamentoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    OrcamentoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoMaterial_materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoMaterial_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoMaterial_MaterialId",
                table: "OrcamentoMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoMaterial_OrcamentoId",
                table: "OrcamentoMaterial",
                column: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_clientes_ClienteId",
                table: "Orcamentos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
