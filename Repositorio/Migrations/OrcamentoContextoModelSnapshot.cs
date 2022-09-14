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

                    b.Property<int?>("AdministradorId")
                        .HasColumnType("int");

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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.ToTable("administradores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "666.999.666-99",
                            DataNascimento = new DateTime(2001, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gugahprm@gmail.com",
                            Endereco = "Rua Julio Michel 1130",
                            Nome = "Gustavo Prim",
                            Telefone = "992499565"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "123.456.789-10",
                            DataNascimento = new DateTime(1995, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucasalves@gmail.com",
                            Endereco = "Rua Água Branca 1234",
                            Nome = "Lucas Alves",
                            Telefone = "992460586"
                        });
                });

            modelBuilder.Entity("Repositorio.Entidades.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("categoria");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)")
                        .HasColumnName("cnpj");

                    b.Property<DateTime>("DataFundacao")
                        .HasMaxLength(8)
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("fornecedores", (string)null);
                });

            modelBuilder.Entity("Repositorio.Entidades.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Repositorio.Entidades.Administrador", b =>
                {
                    b.HasOne("Repositorio.Entidades.Administrador", null)
                        .WithMany("Administradores")
                        .HasForeignKey("AdministradorId");
                });

            modelBuilder.Entity("Repositorio.Entidades.Administrador", b =>
                {
                    b.Navigation("Administradores");
                });
#pragma warning restore 612, 618
        }
    }
}
