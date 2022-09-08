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

            builder.Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasColumnName("cpf");

            builder.Property(x => x.Cnpj)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasColumnName("cnpj");

            builder.Property(x => x.DataNascimento)
                .HasColumnType("DATETIME")
                .IsRequired()
                .HasColumnName("dataNascimento");

            builder.Property(x => x.Endereco)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasColumnName("endereco");

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasColumnName("email");

            builder.Property(x => x.Telefone)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("telefone");

            builder.Property(x => x.Crea)
                .HasColumnType("STRING")
                .IsRequired()
                .HasColumnName("crea");

            // Email, Telefone, Crea.
        }
    }
}