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

            builder.HasData(
                new Estoque
                {
                    Id = 1,
                    Valor = 23.50,
                    Quantidade = 2,
                    MaterialId = 3,
                    FornecedorId = 3,
                    Tipo = Enuns.EstoqueTipo.Entrada,
                },
                   new Estoque
                   {
                       Id = 9,
                       Valor = 25.50,
                       Quantidade = 5,
                       MaterialId = 3,
                       FornecedorId = 3,
                       Tipo = Enuns.EstoqueTipo.Entrada,
                   },
                        new Estoque
                        {
                            Id = 10,
                            Valor = 30.10,
                            Quantidade = 7,
                            MaterialId = 3,
                            FornecedorId = 3,
                            Tipo = Enuns.EstoqueTipo.Entrada,
                        },
                new Estoque
                {
                    Id = 2,
                    Valor = 67.90,
                    Quantidade = 6,
                    MaterialId = 6,
                    FornecedorId = 4,
                    Tipo = Enuns.EstoqueTipo.Saida,
                },
                new Estoque
                {
                    Id = 3,
                    Valor = 50.00,
                    Quantidade = 8,
                    MaterialId = 10,
                    FornecedorId = 2,
                    Tipo = Enuns.EstoqueTipo.Saida,
                },
                new Estoque
                {
                    Id = 4,
                    Valor = 99.99,
                    Quantidade = 10,
                    MaterialId = 6,
                    FornecedorId = 1,
                    Tipo = Enuns.EstoqueTipo.Entrada,
                },
                new Estoque
                {
                    Id = 5,
                    Valor = 76.56,
                    Quantidade = 7,
                    MaterialId = 2,
                    FornecedorId = 1,
                    Tipo = Enuns.EstoqueTipo.Saida,
                },
                new Estoque
                {
                    Id = 6,
                    Valor = 95.34,
                    Quantidade = 19,
                    MaterialId = 4,
                    FornecedorId = 2,
                    Tipo = Enuns.EstoqueTipo.Entrada,
                },
                new Estoque
                {
                    Id = 7,
                    Valor = 100.00,
                    Quantidade = 50,
                    MaterialId = 5,
                    FornecedorId = 3,
                    Tipo = Enuns.EstoqueTipo.Saida,
                },
                new Estoque
                {
                    Id = 8,
                    Valor = 150.00,
                    Quantidade = 75,
                    MaterialId = 2,
                    FornecedorId = 4,
                    Tipo = Enuns.EstoqueTipo.Entrada,
                });

        }
    }
}
