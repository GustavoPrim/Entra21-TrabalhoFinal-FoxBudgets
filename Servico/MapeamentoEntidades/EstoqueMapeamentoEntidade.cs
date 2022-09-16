using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoEntidades
{
    internal class EstoqueMapeamentoEntidade : IEstoqueMapeamentoEntidade
    {
        public void AtualizarCom(Estoque estoque, EstoqueEditarViewModel estoqueEditarViewModel)
        {
            estoque.Nome = estoqueEditarViewModel.Nome;
            estoque.Quantidade = estoqueEditarViewModel.Quantidade;
            estoque.Valor = estoqueEditarViewModel.Valor;
        }

        public Estoque ConstruirCom(EstoqueCadastrarViewModel viewModel)
        {
            return new Estoque
            {
                Nome = viewModel.Nome,
                Quantidade = viewModel.Quantidade,
                Valor = viewModel.Valor,
            };
        }
    }
}
