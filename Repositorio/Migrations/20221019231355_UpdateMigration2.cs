using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class UpdateMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "login",
                value: "Fornecedor1");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "login",
                value: "Fornecedor2");

            migrationBuilder.InsertData(
                table: "fornecedores",
                columns: new[] { "Id", "categoria", "cnpj", "dataFundacao", "email", "endereco", "login", "nome", "senha", "telefone" },
                values: new object[,]
                {
                    { 3, 3, "43.534.987/0001-43", new DateTime(2009, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "juquinhamoveis@gmail.com", "Rua General Osório 1567", "Fornecedor3", "Móveis Juquinha", "7110eda4d09e062aa5e4a390b0a572ac0d2c0220", "4563-9877" },
                    { 4, 0, "23.756.976/0001-65", new DateTime(2009, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaoferramentas@gmail.com", "Rua Água Branca 3333", "Fornecedor4", "Ferramentas do João", "7110eda4d09e062aa5e4a390b0a572ac0d2c0220", "6543-2464" }
                });

            migrationBuilder.InsertData(
                table: "materiais",
                columns: new[] { "Id", "DataValidade", "descricao", "nome", "PossuiDataValidade", "sku" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toalha de Banho adulta", "Toalha de Banho", false, "VFKIY67UI" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mesa de  jantar com seis(6) lugares", "Mesa de Jantar", false, "VFHYU97PO" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Talheres de Aluminio 10 Garfos, 10 Facas e 10 Colheres", "Talher de Alumínio", false, "VGTYU88UI" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conjunto de seis(6) cedeiras", "Cadeira de Ferro", false, "GFRTUI65IJ" },
                    { 5, new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saco de cimento com 50 Kg, tipo fino", "Saco de Cimento", false, "GASDF68KU" },
                    { 6, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saco de granito com 50 Kg tipo 3", "Saco de Granito", false, "HGYIO89LUJ" },
                    { 7, new DateTime(2055, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liquidificador Polishop com Batedeira de Brinde", "Liquidificador Polishop", false, "POUJHB55HJUI" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Televisão da Samsung com 60 Polegadas", "Televisão de 60 Polegadas", false, "YHFGT78OKBG" },
                    { 9, new DateTime(2122, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martelo com cabo de madeira novo", "Martelo", false, "YUGVY298GHYT" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cortina corta-luz, cor cinza", "Cortina", false, "LLKIU764JGU" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "materiais",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "login",
                value: "will");

            migrationBuilder.UpdateData(
                table: "fornecedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "login",
                value: "vg");
        }
    }
}
