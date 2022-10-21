﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio.BancoDados;

#nullable disable

namespace Repositorio.Migrations
{
    [DbContext(typeof(OrcamentoContexto))]
    partial class OrcamentoContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Repositorio.Entidades.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("endereco");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("senha");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("administradores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "666.999.666-99",
                            DataNascimento = new DateTime(2001, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gugahprm@gmail.com",
                            Endereco = "Rua Julio Michel 1130",
                            Login = "guga",
                            Nome = "Gustavo Prim",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "992499565"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "123.456.789-10",
                            DataNascimento = new DateTime(1995, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucasalves@gmail.com",
                            Endereco = "Rua Água Branca 1234",
                            Login = "lucas",
                            Nome = "Lucas Alves",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "992460586"
                        });
                });

            modelBuilder.Entity("Repositorio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(18)
                        .HasColumnType("VARCHAR(18)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Cpf")
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataInspiracaoToken")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("data_Inspiracao_Token");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnType("bit");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("endereco");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("senha");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("telefone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.ToTable("clientes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cnpj = "12.345.678/0001-90",
                            Cpf = "111.222.111-22",
                            DataInspiracaoToken = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascimento = new DateTime(2000, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gugahprm@gmail.com",
                            EmailConfirmado = false,
                            Endereco = "Rua Julio Michel 1130",
                            Login = "gui",
                            Nome = "Guilherme",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "992499565",
                            Token = "00000000-0000-0000-0000-000000000000"
                        },
                        new
                        {
                            Id = 2,
                            Cnpj = "77.888.777/0001-10",
                            Cpf = "444.555.444-55",
                            DataInspiracaoToken = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascimento = new DateTime(1997, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucasalves@gmail.com",
                            EmailConfirmado = false,
                            Endereco = "Rua Hermann Tribess 1234",
                            Login = "ju",
                            Nome = "Juliana",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "992380457",
                            Token = "00000000-0000-0000-0000-000000000000"
                        });
                });

            modelBuilder.Entity("Repositorio.Entidades.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("Repositorio.Entidades.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Categoria")
                        .HasColumnType("INT")
                        .HasColumnName("categoria");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(18)
                        .HasColumnType("VARCHAR(18)")
                        .HasColumnName("cnpj");

                    b.Property<string>("Cpf")
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataFundacao")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("dataFundacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("VARCHAR(25)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("endereco");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("senha");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("fornecedores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria = 1,
                            Cnpj = "34.568.789/0001-25",
                            DataFundacao = new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Willljdev@gmail.com",
                            Endereco = "Rua 2 de Setembro 1890",
                            Login = "Fornecedor1",
                            Nome = "Wolf Tubos e conexões",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "991599314"
                        },
                        new
                        {
                            Id = 2,
                            Categoria = 4,
                            Cpf = "089.567.453-87",
                            DataFundacao = new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "budgetsVG@gmail.com",
                            Endereco = "Rua Alberto Stein 199",
                            Login = "Fornecedor2",
                            Nome = "Materiais de construção VG",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "3381-7700"
                        },
                        new
                        {
                            Id = 3,
                            Categoria = 3,
                            Cnpj = "43.534.987/0001-43",
                            DataFundacao = new DateTime(2009, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "juquinhamoveis@gmail.com",
                            Endereco = "Rua General Osório 1567",
                            Login = "Fornecedor3",
                            Nome = "Móveis Juquinha",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "4563-9877"
                        },
                        new
                        {
                            Id = 4,
                            Categoria = 0,
                            Cpf = "567.453.676-99",
                            DataFundacao = new DateTime(2009, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joaoferramentas@gmail.com",
                            Endereco = "Rua Água Branca 3333",
                            Login = "Fornecedor4",
                            Nome = "Ferramentas do João",
                            Senha = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220",
                            Telefone = "6543-2464"
                        });
                });

            modelBuilder.Entity("Repositorio.Entidades.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("DataValidade");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.Property<bool>("PossuiDataValidade")
                        .HasColumnType("BIT")
                        .HasColumnName("PossuiDataValidade");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("VARCHAR(16)")
                        .HasColumnName("sku");

                    b.HasKey("Id");

                    b.ToTable("materiais", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataValidade = new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Toalha de Banho adulta",
                            Nome = "Toalha de Banho",
                            PossuiDataValidade = false,
                            Sku = "VFKIY67UI"
                        },
                        new
                        {
                            Id = 2,
                            DataValidade = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Mesa de  jantar com seis(6) lugares",
                            Nome = "Mesa de Jantar",
                            PossuiDataValidade = false,
                            Sku = "VFHYU97PO"
                        },
                        new
                        {
                            Id = 3,
                            DataValidade = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Talheres de Aluminio 10 Garfos, 10 Facas e 10 Colheres",
                            Nome = "Talher de Alumínio",
                            PossuiDataValidade = false,
                            Sku = "VGTYU88UI"
                        },
                        new
                        {
                            Id = 4,
                            DataValidade = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Conjunto de seis(6) cedeiras",
                            Nome = "Cadeira de Ferro",
                            PossuiDataValidade = false,
                            Sku = "GFRTUI65IJ"
                        },
                        new
                        {
                            Id = 5,
                            DataValidade = new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Saco de cimento com 50 Kg, tipo fino",
                            Nome = "Saco de Cimento",
                            PossuiDataValidade = false,
                            Sku = "GASDF68KU"
                        },
                        new
                        {
                            Id = 6,
                            DataValidade = new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Saco de granito com 50 Kg tipo 3",
                            Nome = "Saco de Granito",
                            PossuiDataValidade = false,
                            Sku = "HGYIO89LUJ"
                        },
                        new
                        {
                            Id = 7,
                            DataValidade = new DateTime(2055, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Liquidificador Polishop com Batedeira de Brinde",
                            Nome = "Liquidificador Polishop",
                            PossuiDataValidade = false,
                            Sku = "POUJHB55HJUI"
                        },
                        new
                        {
                            Id = 8,
                            DataValidade = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Televisão da Samsung com 60 Polegadas",
                            Nome = "Televisão de 60 Polegadas",
                            PossuiDataValidade = false,
                            Sku = "YHFGT78OKBG"
                        },
                        new
                        {
                            Id = 9,
                            DataValidade = new DateTime(2122, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Martelo com cabo de madeira novo",
                            Nome = "Martelo",
                            PossuiDataValidade = false,
                            Sku = "YUGVY298GHYT"
                        },
                        new
                        {
                            Id = 10,
                            DataValidade = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Cortina corta-luz, cor cinza",
                            Nome = "Cortina",
                            PossuiDataValidade = false,
                            Sku = "LLKIU764JGU"
                        });
                });

            modelBuilder.Entity("Repositorio.Entidades.Orcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("Repositorio.Entidades.OrcamentoMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Item")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("INT")
                        .HasColumnName("material_id");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("INT")
                        .HasColumnName("orcamento_id");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INT")
                        .HasColumnName("quantidade_id");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("orcamentos_materiais", (string)null);
                });

            modelBuilder.Entity("Repositorio.Entidades.Estoque", b =>
                {
                    b.HasOne("Repositorio.Entidades.Estoque", null)
                        .WithMany("EstoqueMaterial")
                        .HasForeignKey("EstoqueId");

                    b.HasOne("Repositorio.Entidades.Fornecedor", "Fornecedor")
                        .WithMany("Estoques")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositorio.Entidades.Material", "Material")
                        .WithMany("Estoques")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Repositorio.Entidades.Orcamento", b =>
                {
                    b.HasOne("Repositorio.Entidades.Cliente", "Cliente")
                        .WithMany("Orcamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Repositorio.Entidades.OrcamentoMaterial", b =>
                {
                    b.HasOne("Repositorio.Entidades.Material", "Material")
                        .WithMany("OrcamentoMateriais")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repositorio.Entidades.Orcamento", "Orcamento")
                        .WithMany("OrcamentoMateriais")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("Repositorio.Entidades.Cliente", b =>
                {
                    b.Navigation("Orcamentos");
                });

            modelBuilder.Entity("Repositorio.Entidades.Estoque", b =>
                {
                    b.Navigation("EstoqueMaterial");
                });

            modelBuilder.Entity("Repositorio.Entidades.Fornecedor", b =>
                {
                    b.Navigation("Estoques");
                });

            modelBuilder.Entity("Repositorio.Entidades.Material", b =>
                {
                    b.Navigation("Estoques");

                    b.Navigation("OrcamentoMateriais");
                });

            modelBuilder.Entity("Repositorio.Entidades.Orcamento", b =>
                {
                    b.Navigation("OrcamentoMateriais");
                });
#pragma warning restore 612, 618
        }
    }
}
