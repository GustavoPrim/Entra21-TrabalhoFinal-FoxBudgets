using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.MapeamentoEntidades
{
    public interface IOrcamentoMapeamentoEntidade
    {
        Orcamento ConstruirCom(OrcamentoCadastrarViewModel viewModel);
        void AtualizarCom(Orcamento orcamento, OrcamentoEditarViewModel viewModel);
    }
}
