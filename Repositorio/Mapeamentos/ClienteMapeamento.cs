using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    internal class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(18)
                .IsRequired()
                .HasColumnName("cpf");

            builder.Property(x => x.Cnpj)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired()
                .HasColumnName("cnpj");

            builder.Property(x => x.DataNascimento)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("DataNascimento");

            builder.Property(x => x.Endereco)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("endereco");

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(x => x.Telefone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .HasColumnName("telefone");

            builder.Property(x => x.Crea)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("crea");

            builder.HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "Gustavo Prim",
                    Cpf = "111.222.111-22",
                    Cnpj = "12.345.678/0001-90",
                    DataNascimento = new DateTime(2000, 08, 18),
                    Endereco = "Rua Julio Michel 1130",
                    Email = "gugahprm@gmail.com",
                    Telefone = "992499565",
                    Crea = "1234567"
                },
                new Cliente
                {
                    Id = 2,
                    Nome = "Lucas Alves",
                    Cpf = "444.555.444-55",
                    Cnpj = "77.888.777/0001-10",
                    DataNascimento = new DateTime(1997, 08, 31),
                    Endereco = "Rua Hermann Tribess 1234",
                    Email = "lucasalves@gmail.com",
                    Telefone = "992380457",
                    Crea = "7654321"
                });
        }
    }
}