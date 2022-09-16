using Repositorio.Entidades;
using Servico.ViewModels.Estoque;

namespace Servico.Servicos
{
    public interface IEstoqueServico
    {
        Estoque CadastrarValor(EstoqueCadastrarViewModel viewModel);
        bool Editar(EstoqueEditarViewModel viewModel);
        bool Apagar(int id);
        Estoque? ObterPorId(int id);
        IList<Estoque> ObterTodos();
    }
}
