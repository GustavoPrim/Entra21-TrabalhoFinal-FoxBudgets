using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    internal class AdministradorMapeamento : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.ToTable("administradores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Nome)
                .HasColumnName("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(x => x.Cpf)
                .HasColumnName("STRING")
                .IsRequired()
                .HasColumnName("cpf");

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DATETIME2")
                .IsRequired()
                .HasColumnName("DataNascimento");

            builder.Property(x => x.Endereco)
                .HasColumnName("VARCHAR")
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("endereco");

            builder.Property(x => x.Email)
                .HasColumnName("STRING")
                .IsRequired()
                .HasColumnName("email");

            builder.Property(x => x.Telefone)
                .HasColumnName("INT");

            builder.Property(x => x.Genero)
                .HasColumnName("BIT")
                .HasDefaultValue(true);
        }
    }
}