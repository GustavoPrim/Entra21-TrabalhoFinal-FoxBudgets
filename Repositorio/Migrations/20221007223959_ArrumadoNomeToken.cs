using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class ArrumadoNomeToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "clientes",
                newName: "token");

            migrationBuilder.RenameColumn(
                name: "DataInspiracaoToken",
                table: "clientes",
                newName: "data_Inspiracao_Token");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "clientes",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_Inspiracao_Token",
                table: "clientes",
                type: "DATETIME2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "token",
                value: "00000000-0000-0000-0000-000000000000");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "token",
                value: "00000000-0000-0000-0000-000000000000");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "token",
                table: "clientes",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "data_Inspiracao_Token",
                table: "clientes",
                newName: "DataInspiracaoToken");

            migrationBuilder.AlterColumn<Guid>(
                name: "Token",
                table: "clientes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInspiracaoToken",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Token",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Token",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
