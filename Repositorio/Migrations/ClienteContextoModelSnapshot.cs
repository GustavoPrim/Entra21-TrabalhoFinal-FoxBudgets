using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repositorio.BancoDados;

namespace Repositorio.Migrations
{
    [DbContext(typeof(ClienteContexto))]
    partial class ClienteContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7").HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Repositorio.Entidades.Cliente",b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<string>("Cpf").IsRequired().HasMaxLength(11).HasColumnType("VARCHAR(11)").HasColumnName("cpf");

                b.Property<string>("Cnpj").IsRequired().HasMaxLength(14).HasColumnType("VARCHAR(14)").HasColumnName("cnpj");

                b.HasKey("Id").HasName("id");
            });
        }
    }
}