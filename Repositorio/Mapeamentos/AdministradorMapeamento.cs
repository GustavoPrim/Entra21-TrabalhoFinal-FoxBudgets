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
                .HasColumnName("STRING")
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnName("Nome");
        }
    }
}
