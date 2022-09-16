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

            builder.Property(x => x.Nome)
               .HasColumnType("VARCHAR")
               .HasMaxLength(100)
               .IsRequired()
               .HasColumnName("nome");

            builder.Property(x => x.Quantidade)
               .HasColumnType("INT")
               .HasMaxLength(500)
               .IsRequired()
               .HasColumnName("quantidade");

            builder.Property(x => x.Valor)
               .HasColumnType("Double")
               .IsRequired()
               .HasColumnName("valor");
        }
    }
}
