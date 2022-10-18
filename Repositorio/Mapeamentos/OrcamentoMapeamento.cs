using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class OrcamentoMapeamento : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("orcamentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClienteId)
               .HasColumnType("INT")
               .IsRequired()
               .HasColumnName("cliente_id");

            builder.Property(x => x.Numero)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("numero");

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Orcamentos)
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
