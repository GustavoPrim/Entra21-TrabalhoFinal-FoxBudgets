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

            builder.HasData(
                new Material
                {
                    Id = 1,
                    Nome = "Toalha de Banho",
                    Sku = "VFKIY67UI",
                    DataValidade = new DateTime(2023, 08, 14),
                    Descricao = "Toalha de Banho adulta"
                },
                new Material
                {
                    Id = 2,
                    Nome = "Mesa de Jantar",
                    Sku = "VFHYU97PO",
                    PossuiDataValidade = false,
                    Descricao = "Mesa de  jantar com seis(6) lugares"
                },
                new Material
                {
                    Id = 3,
                    Nome = "Talher de Alumínio",
                    Sku = "VGTYU88UI",
                    PossuiDataValidade = false,
                    Descricao = "Talheres de Aluminio 10 Garfos, 10 Facas e 10 Colheres"
                },
                new Material
                {
                    Id = 4,
                    Nome = "Cadeira de Ferro",
                    Sku = "GFRTUI65IJ",
                    PossuiDataValidade = false,
                    Descricao = "Conjunto de seis(6) cedeiras"
                },
                new Material
                {
                    Id = 5,
                    Nome = "Saco de Cimento",
                    Sku = "GASDF68KU",
                    DataValidade = new DateTime(2025, 08, 14),
                    Descricao = "Saco de cimento com 50 Kg, tipo fino"
                },
                new Material
                {
                    Id = 6,
                    Nome = "Saco de Granito",
                    Sku = "HGYIO89LUJ",
                    DataValidade = new DateTime(2025, 07, 14),
                    Descricao = "Saco de granito com 50 Kg tipo 3"
                },
                new Material
                {
                    Id = 7,
                    Nome = "Liquidificador Polishop",
                    Sku = "POUJHB55HJUI",
                    DataValidade = new DateTime(2055, 08, 14),
                    Descricao = "Liquidificador Polishop com Batedeira de Brinde"
                },
                new Material
                {
                    Id = 8,
                    Nome = "Televisão de 60 Polegadas",
                    Sku = "YHFGT78OKBG",
                    PossuiDataValidade = false,
                    Descricao = "Televisão da Samsung com 60 Polegadas"
                },
                new Material
                {
                    Id = 9,
                    Nome = "Martelo",
                    Sku = "YUGVY298GHYT",
                    DataValidade = new DateTime(2122, 08, 14),
                    Descricao = "Martelo com cabo de madeira novo"
                },
                new Material
                {
                    Id = 10,
                    Nome = "Cortina",
                    Sku = "LLKIU764JGU",
                    PossuiDataValidade = false,
                    Descricao = "Cortina corta-luz, cor cinza"
                });
        }
    }
}