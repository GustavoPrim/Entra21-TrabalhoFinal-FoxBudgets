using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Mapeamentos
{
    public class OrcamentoMapeamento : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("orcamentos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Numero)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("Número da cotação");

            builder.Property(x => x.DataOrcamento)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("Data do orçamento");

            builder.Property(x => x.Item)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasColumnName("Item");

            builder.Property(x => x.Quantidade)
                .HasColumnType("INTEGER")
                .IsRequired()
                .HasColumnName("Data do orçamento");

            builder.Property(x => x.ValorUnitarioItem)
                .HasColumnType("DOUBLE")
                .IsRequired()
                .HasColumnName("Valor unitário do item");

            builder.Property(x => x.ValorTotalItem)
                .HasColumnType("DOUBLE")
                .IsRequired()
                .HasColumnName("Valor total do item");

            builder.Property(x => x.ValorTotalOrcamento)
                .HasColumnType("DOUBLE")
                .IsRequired()
                .HasColumnName("Valor total do orçamento");
        }
    }
}
