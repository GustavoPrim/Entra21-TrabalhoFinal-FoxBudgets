using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public interface IOrcamentoServico
    {
        Orcamento Cotar(OrcamentoCadastrarViewModel viewModel, int clienteId);
        bool Editar(OrcamentoEditarViewModel viewModel);
        Orcamento ObterPorId(int id);
        List<Orcamento> ObterTodos();
        bool Apagar(int id);
    }
}
