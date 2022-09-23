using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public interface IOrcamentoRepositorio
    {
        Orcamento Cotar(Orcamento orcamento);
        void Editar(Orcamento orcamento);
        Orcamento ObterPorId(int id);
        IList<Orcamento> ObterTodos();
        bool Apagar(int id);
    }
}
