using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;

namespace Servico.MapeamentoViewModels
{
    public interface IOrcamentoMapeamentoViewModel
    {
        OrcamentoEditarViewModel ConstruirCom(Orcamento orcamento);
    }
}