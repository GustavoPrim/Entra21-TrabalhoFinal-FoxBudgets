using Repositorio.Entidades;
using Repositorio.Enuns;
using Servico.ViewModels.Estoque;

namespace Servico.MapeamentoEntidades
{
    public class EstoqueMapeamentoEntidade : IEstoqueMapeamentoEntidade
    {
        public void AtualizarCom(Estoque estoque, EstoqueEditarViewModel estoqueEditarViewModel)
        {
            estoque.Quantidade = estoqueEditarViewModel.Quantidade;
        }

        public Estoque ConstruirCom(EstoqueCadastrarViewModel viewModel, int fornecedorId)
        {
            return new Estoque
            {
                Quantidade = viewModel.Quantidade,
                FornecedorId = fornecedorId,
                MaterialId = viewModel.Item,
                Valor = viewModel.Valor,
                Tipo = EstoqueTipo.Entrada
            };
        }
    }
}