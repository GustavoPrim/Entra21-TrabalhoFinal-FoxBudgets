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
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
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
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("email");

            builder.Property(x => x.Telefone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .HasColumnName("telefone");

            builder.Property(x => x.Login)
              .HasColumnName("login")
              .HasColumnType("VARCHAR")
              .HasMaxLength(100);

            builder.Property(x => x.Senha)
               .HasColumnName("senha")
               .HasColumnType("VARCHAR")
               .HasMaxLength(100);


            builder.HasData(
                new Administrador
                {
                    Id = 1,
                    Nome = "Gustavo Prim",
                    Cpf = "666.999.666-99",
                    DataNascimento = new DateTime(2001, 04, 23),
                    Endereco = "Rua Julio Michel 1130",
                    Email = "gugahprm@gmail.com",
                    Telefone = "992499565",
                    Login = "guga",
                    Senha = "1234"
                },
                new Administrador
                {
                    Id = 2,
                    Nome = "Lucas Alves",
                    Cpf = "123.456.789-10",
                    DataNascimento = new DateTime(1995, 12, 19),
                    Endereco = "Rua Água Branca 1234",
                    Email = "lucasalves@gmail.com",
                    Telefone = "992460586",
                    Login = "Lucas",
                    Senha = "1234"
                });
        }
    }
}