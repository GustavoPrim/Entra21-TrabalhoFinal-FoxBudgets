using Repositorio.Entidades;
using Servico.ViewModels.Estoque;
using Servico.ViewModels.Orcamentos;

namespace Servico.Servicos
{
    public interface IEstoqueServico
    {
        Estoque Estocar(EstoqueCadastrarViewModel viewModel, int fornecedorId);
        Estoque? ObterPorId(int id);
        IList<Estoque> ObterTodos();
        List<EstoqueItemIndexViewModel> ObterItensEstoqueAtual(int idUsuarioLogado);

    }
}
