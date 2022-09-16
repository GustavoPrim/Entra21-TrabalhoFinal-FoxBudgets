using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoEntidades
{
    public interface IEstoqueMapeamentoEntidade
    {
        Estoque ConstruirCom(EstoqueCadastrarViewModel viewModel);
        void AtualizarCom(Estoque estoque, EstoqueEditarViewModel estoqueEditarViewModel);
    }
}
