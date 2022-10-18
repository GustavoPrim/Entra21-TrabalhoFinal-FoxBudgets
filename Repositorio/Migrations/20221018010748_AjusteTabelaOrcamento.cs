using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AjusteTabelaOrcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataOrcamento",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Item",
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

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Estoque",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Estoque");

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
        }
    }
}
