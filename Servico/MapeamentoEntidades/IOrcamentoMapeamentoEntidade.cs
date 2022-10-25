using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;

namespace Servico.MapeamentoEntidades
{
    public interface IOrcamentoMapeamentoEntidade
    {
        OrcamentoMaterial ConstruirCom(OrcamentoCadastrarViewModel viewModel);
        void AtualizarCom(OrcamentoMaterial orcamento, OrcamentoEditarViewModel viewModel);
    }
}