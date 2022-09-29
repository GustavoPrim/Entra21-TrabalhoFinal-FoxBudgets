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
        OrcamentoMaterial Cotar(OrcamentoCadastrarViewModel viewModel);
        bool Editar(OrcamentoEditarViewModel viewModel);
        OrcamentoMaterial ObterPorId(int id);
        List<OrcamentoMaterial> ObterTodos();
        bool Apagar(int id);
    }
}
