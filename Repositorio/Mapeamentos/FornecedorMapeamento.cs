using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;
using Repositorio.Enuns;
using Repositorio.Repositorios;

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
            
            builder.Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired()
                .HasColumnName("cpf");

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
                    Cnpj = "34.56.789/0001-25",
                    DataFundacao = new DateTime(2020, 03, 15),
                    Endereco = "Rua 2 de Setembro 1890",
                    Email = "Willljdev@gmail.com",
                    Telefone = "991599314",
                    Categoria = AdministradorEnum.MaterialHidraulico,
                    Login = "Fornecedor1",
                    Senha = "1234".GerarHash()
                },
                new Fornecedor
                {
                    Id = 2,
                    Nome = "Materiais de construção VG",
                    Cpf = "089.567.453-87",
                    DataFundacao = new DateTime(2019, 09, 18),
                    Endereco = "Rua Alberto Stein 199",
                    Email = "budgetsVG@gmail.com",
                    Telefone = "3381-7700",
                    Categoria = AdministradorEnum.MaterialBruto,
                    Login = "Fornecedor2",
                    Senha = "1234".GerarHash()
                },
                new Fornecedor
                {
                    Id = 3,
                    Nome = "Móveis Juquinha",
                    Cnpj = "43.534.987/0001-43",
                    DataFundacao = new DateTime(2009, 09, 18),
                    Endereco = "Rua General Osório 1567",
                    Email = "juquinhamoveis@gmail.com",
                    Telefone = "4563-9877",
                    Categoria = AdministradorEnum.Tintas,
                    Login = "Fornecedor3",
                    Senha = "1234".GerarHash()
                },
                new Fornecedor
                {
                    Id = 4,
                    Nome = "Ferramentas do João",
                    Cpf = "567.453.676-99",
                    DataFundacao = new DateTime(2009, 09, 18),
                    Endereco = "Rua Água Branca 3333",
                    Email = "joaoferramentas@gmail.com",
                    Telefone = "6543-2464",
                    Categoria = AdministradorEnum.MaterialEletrico,
                    Login = "Fornecedor4",
                    Senha = "1234".GerarHash()
                });
        }
    }
}