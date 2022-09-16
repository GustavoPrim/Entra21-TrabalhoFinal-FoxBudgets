using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class AdministradorMapeamento : IEntityTypeConfiguration<Adm>
    {
        public void Configure(EntityTypeBuilder<Adm> builder)
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

                .HasMaxLength(100)
                .HasColumnName("telefone");

            builder.HasData(
                new Adm
                {
                    Id = 1,
                    Nome = "Gustavo Prim",
                    Cpf = "666.999.666-99",
                    DataNascimento = new DateTime(2001, 04, 23),
                    Endereco = "Rua Julio Michel 1130",
                    Email = "gugahprm@gmail.com",
                    Telefone = "992499565"
                },
                new Adm
                {
                    Id = 2,
                    Nome = "Lucas Alves",
                    Cpf = "123.456.789-10",
                    DataNascimento = new DateTime(1995, 12, 19),
                    Endereco = "Rua Água Branca 1234",
                    Email = "lucasalves@gmail.com",
                    Telefone = "992460586"
                });
        }
    }
}