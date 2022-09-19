using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;
using Repositorio.Enuns;

namespace Repositorio.Mapeamentos
{
    public class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(x => x.Cnpj)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired()
                .HasColumnName("cnpj");

            builder.Property(x => x.DataFundacao)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("dataFundacao");

            builder.Property(x => x.Endereco)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("endereco");

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(25)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(X => X.Telefone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("telefone");

            builder.Property(x => x.Categoria)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("categoria");

            builder.Property(x => x.Login)
              .HasColumnName("login")
              .HasColumnType("VARCHAR")
              .HasMaxLength(100);

            builder.Property(x => x.Senha)
               .HasColumnName("senha")
               .HasColumnType("VARCHAR")
               .HasMaxLength(100);

            builder.HasData(
                new Fornecedor
                {
                    Id = 1,
                    Nome = "Wolf Tubos e conexões",
                    Cnpj = "",
                    DataFundacao = new DateTime(2020, 03, 15),
                    Endereco = "Rua 2 de Setembro 1890",
                    Email = "Willljdev@gmail.com",
                    Telefone = "991599314",
                    Categoria = (int)AdministradorEnum.MaterialHidraulico,
                    Login = "will",
                    Senha = "1234"
                },
                new Fornecedor
                {
                    Id = 2,
                    Nome = "Materiais de construção VG",
                    Cnpj = "",
                    DataFundacao = new DateTime(2019, 09, 18),
                    Endereco = "Rua Alberto Stein 199",
                    Email = "budgetsVG@gmail.com",
                    Telefone = "3381-7700",
                    Categoria = (int)AdministradorEnum.MaterialBruto,
                    Login = "vg",
                    Senha = "1234"
                });
        }
    }
}