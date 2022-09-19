using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class OrcamentoMaterialMapeamento : IEntityTypeConfiguration<OrcamentoMaterial>
    {
        public void Configure(EntityTypeBuilder<OrcamentoMaterial> builder)
        {
            builder.ToTable("orcamentos_materiais");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaterialId)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("material_id");

            builder.Property(x => x.OrcamentoId)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("orcamento_id");

            builder.Property(x => x.Quantidade)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("quantidade_id");

            builder.HasOne(x => x.Material)
                .WithMany(x => x.OrcamentoMateriais)
                .HasForeignKey(x => x.MaterialId);

            builder.HasOne(x => x.Orcamento)
                .WithMany(x => x.OrcamentoMateriais)
                .HasForeignKey(x => x.OrcamentoId);
        }
    }
}
