using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class MaterialMapeamento : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("materiais");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(x => x.Sku)
                .HasColumnType("VARCHAR")
                .HasMaxLength(16)
                .IsRequired()
                .HasColumnName("sku");

            builder.Property(x => x.PossuiDataValidade)
                .HasColumnType("BIT")
                .HasColumnName("PossuiDataValidade");

            builder.Property(x => x.DataValidade)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("DataValidade");

            builder.Property(x => x.Descricao)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .HasColumnName("descricao");

        }
    }
}