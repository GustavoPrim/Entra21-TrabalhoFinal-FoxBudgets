using Microsoft.EntityFrameworkCore;
using Repositorio.Entidades;

namespace Repositorio.BancoDados
{
    public class OrcamentoContexto : DbContext
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public OrcamentoContexto(
            DbContextOptions<OrcamentoContexto> options)
            : base(options)
        {
        }
    }
}
