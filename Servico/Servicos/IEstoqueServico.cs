using Repositorio.Entidades;
using Servico.ViewModels.Estoque;
using Servico.ViewModels.Orcamentos;

namespace Servico.Servicos
{
    public interface IEstoqueServico
    {
        Estoque CadastrarValor(EstoqueCadastrarViewModel viewModel, int fornecedorId);
        Estoque CadastrarQuantidade(EstoqueCadastrarViewModel viewModel, int fornecedorId);
        bool Editar(EstoqueEditarViewModel viewModel);
        Estoque Estocar(EstoqueCadastrarViewModel viewModel, int fornecedorId);
        bool Apagar(int id);
        Estoque? ObterPorId(int id);
        IList<Estoque> ObterTodos();
        List<EstoqueItemIndexViewModel> ObterItensEstoqueAtual(int idUsuarioLogado);

    }
}
