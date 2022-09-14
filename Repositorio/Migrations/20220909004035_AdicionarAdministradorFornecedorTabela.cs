using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    public partial class AdicionarAdministradorFornecedorTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpf = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: true),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_administradores_administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "administradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    dataFundacao = table.Column<DateTime>(type: "DATETIME2", maxLength: 8, nullable: false),
                    endereco = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "administradores",
                columns: new[] { "Id", "AdministradorId", "cpf", "DataNascimento", "email", "endereco", "nome", "telefone" },
                values: new object[] { 1, null, "666.999.666-99", new DateTime(2001, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "gugahprm@gmail.com", "Rua Julio Michel 1130", "Gustavo Prim", "992499565" });

            migrationBuilder.InsertData(
                table: "administradores",
                columns: new[] { "Id", "AdministradorId", "cpf", "DataNascimento", "email", "endereco", "nome", "telefone" },
                values: new object[] { 2, null, "123.456.789-10", new DateTime(1995, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucasalves@gmail.com", "Rua Água Branca 1234", "Lucas Alves", "992460586" });

            migrationBuilder.CreateIndex(
                name: "IX_administradores_AdministradorId",
                table: "administradores",
                column: "AdministradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administradores");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
