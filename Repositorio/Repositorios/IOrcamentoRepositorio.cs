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
        Orcamento Cotar(Orcamento orcamentoMaterial);
        void Editar(Orcamento orcamentoMaterial);
        Orcamento ObterPorId(int id);
        List<Orcamento> ObterTodos();
        bool Apagar(int id);
        Orcamento? ObterPorClienteId(int idCliente);
        void CrirOuAtualizar(Orcamento orcamento);
    }
}
