using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class EstruturaBancoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    login = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(18)", maxLength: 18, nullable: false),
                    cnpj = table.Column<string>(type: "VARCHAR(18)", maxLength: 18, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    cnpj = table.Column<string>(type: "VARCHAR(18)", maxLength: 18, nullable: false),
                    dataFundacao = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    login = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    categoria = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "materiais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    sku = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    DataValidade = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    descricao = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    PossuiDataValidade = table.Column<bool>(type: "BIT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estoque_materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrcamentoId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_OrcamentoMaterial_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "administradores",
                columns: new[] { "Id", "cpf", "DataNascimento", "email", "endereco", "login", "nome", "senha", "telefone" },
                values: new object[,]
                {
                    { 1, "666.999.666-99", new DateTime(2001, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "gugahprm@gmail.com", "Rua Julio Michel 1130", "guga", "Gustavo Prim", "1234", "992499565" },
                    { 2, "123.456.789-10", new DateTime(1995, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucasalves@gmail.com", "Rua Água Branca 1234", "lucas", "Lucas Alves", "1234", "992460586" }
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "Id", "cnpj", "cpf", "DataNascimento", "email", "endereco", "Login", "nome", "senha", "telefone" },
                values: new object[,]
                {
                    { 1, "12.345.678/0001-90", "111.222.111-22", new DateTime(2000, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "gugahprm@gmail.com", "Rua Julio Michel 1130", "gui", "Guilherme", "1234", "992499565" },
                    { 2, "77.888.777/0001-10", "444.555.444-55", new DateTime(1997, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucasalves@gmail.com", "Rua Hermann Tribess 1234", "ju", "Juliana", "1234", "992380457" }
                });

            migrationBuilder.InsertData(
                table: "fornecedores",
                columns: new[] { "Id", "categoria", "cnpj", "dataFundacao", "email", "endereco", "login", "nome", "senha", "telefone" },
                values: new object[,]
                {
                    { 1, 1, "", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willljdev@gmail.com", "Rua 2 de Setembro 1890", "will", "Wolf Tubos e conexões", "1234", "991599314" },
                    { 2, 4, "", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "budgetsVG@gmail.com", "Rua Alberto Stein 199", "vg", "Materiais de construção VG", "1234", "3381-7700" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_FornecedorId",
                table: "Estoque",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_MaterialId",
                table: "Estoque",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_ClienteId",
                table: "Orcamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoMaterial_MaterialId",
                table: "OrcamentoMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoMaterial_OrcamentoId",
                table: "OrcamentoMaterial",
                column: "OrcamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administradores");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "OrcamentoMaterial");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.DropTable(
                name: "materiais");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
