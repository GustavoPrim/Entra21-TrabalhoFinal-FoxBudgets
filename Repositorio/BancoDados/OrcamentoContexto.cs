using Microsoft.EntityFrameworkCore;
using Repositorio.Entidades;
using Repositorio.Mapeamentos;

namespace Repositorio.BancoDados
{
    public class OrcamentoContexto : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public OrcamentoContexto(
            DbContextOptions<OrcamentoContexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdministradorMapeamento());
            modelBuilder.ApplyConfiguration(new FornecedorMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
        }
    }
}
