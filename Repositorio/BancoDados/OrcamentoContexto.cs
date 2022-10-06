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
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<OrcamentoMaterial> Orcamentos { get; set; }

        public OrcamentoContexto(
            DbContextOptions<OrcamentoContexto> options)
            : base(options)
        {
            // dotnet ef migrations add AdicionarAdministradorFornecedorTabela --project Repositorio --startup-project .\Aplicacao

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdministradorMapeamento());
            modelBuilder.ApplyConfiguration(new FornecedorMapeamento());
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration(new MaterialMapeamento());
        }
    }
}
