using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoEntidades
{
    public class EstoqueMapeamentoEntidade : IEstoqueMapeamentoEntidade
    {
        public void AtualizarCom(Estoque estoque, EstoqueEditarViewModel estoqueEditarViewModel)
        {
            estoque.Quantidade = estoqueEditarViewModel.Quantidade;
        }
        public Estoque ConstruirCom(EstoqueCadastrarViewModel viewModel)
        {
            return new Estoque
            {
                Quantidade = viewModel.Quantidade,
            };
        }
    }
}
