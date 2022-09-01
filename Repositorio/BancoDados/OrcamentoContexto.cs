using Microsoft.EntityFrameworkCore;
using Repositorio.Entidades;

namespace Repositorio.BancoDados
{
    internal class OrcamentoContexto
    {
        public DbSet<Administrador> Administradores { get; set; }
    }
}
