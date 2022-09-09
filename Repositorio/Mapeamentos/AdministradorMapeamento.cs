using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repositorio.Entidades;

namespace Repositorio.Mapeamentos
{
    public class AdministradorMapeamento : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.ToTable("administradores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("nome");

            builder.Property(x => x.Cpf)
                .HasColumnType("STRING")
                .IsRequired()
                .HasColumnName("cpf");

            builder.Property(x => x.DataNascimento)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("DataNascimento");

            builder.Property(x => x.Endereco)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnName("endereco");

            builder.Property(x => x.Email)
                .HasColumnType("STRING")
                .IsRequired()
                .HasColumnName("email");

            builder.Property(x => x.Telefone)
                .HasColumnType("INT");

            builder.HasData(
                new Administrador
                {
                    Id = 1,
                    Nome = "Gustavo Prim",
                    Cpf = "666.999.666-99",
                    //DataNascimento = ,
                    Endereco = "Rua Julio Michel 1130",
                    Email = "gugahprm@gmail.com",
                    Telefone = 992499565
                },
                new Administrador
                {
                    Id = 2,
                    Nome = "Lucas Alves",
                    Cpf = "123.456.789-10",
                    //DataNascimento = 
                    Endereco = "Rua Água Branca 1234",
                    Email = "lucasalves@gmail.com",
                    Telefone = 992460586
                });
        }
    }
}