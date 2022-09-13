using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

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
                .HasMaxLength(20)
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

            builder.HasData(
                new Fornecedor
                {
                    Id = 1,
                    Nome = "Wolf's Orçamentos",
                    Cnpj = "12.345.678/0001-99",
                    DataFundacao = new DateTime(2020, 08, 18),
                    Endereco = "Rua Dois de Setembro 1895",
                    Email = "wolfsacessoria@gmail.com",
                    Telefone = "3381-0987"
                },
                new Fornecedor
                {
                    Id = 2,
                    Nome = "Budgets VG",
                    Cnpj = "99.888.777/0001-10",
                    DataFundacao = new DateTime(2019, 09, 14),
                    Endereco = "Rua Alberto Stein 199",
                    Email = "gugahprm@gmail.com",
                    Telefone = "991509314"
                });
        }
    }
}