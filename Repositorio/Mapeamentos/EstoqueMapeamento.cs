using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class EstoqueMapeamento : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("estoques");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("quantidade");

            builder.Property(x => x.MaterialId)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("material_id");

            builder.Property(x => x.FornecedorId)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("fornecedor_id");

            builder.Property(x => x.Tipo)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("tipo");

            builder.HasOne(x => x.Material)
                .WithMany(x => x.Estoques)
                .HasForeignKey(x => x.MaterialId);

            builder.HasOne(x => x.Fornecedor)
                .WithMany(x => x.Estoques)
                .HasForeignKey(x => x.FornecedorId);

        }
    }
}
