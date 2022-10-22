using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoEntidades
{
    public interface IEstoqueMapeamentoEntidade
    {
        Estoque ConstruirCom(EstoqueCadastrarViewModel viewModel, int fornecedorId);
        void AtualizarCom(Estoque estoque, EstoqueEditarViewModel estoqueEditarViewModel);
    }
}
