using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos
{
    public interface IFornecedorServico
    {
        bool Apagar(int id);
        Fornecedor Cadastrar(FornecedorCadastrarViewModel viewModel);
        bool Editar(FornecedorEditarViewModel viewModel);
        Fornecedor? ObterPorId(int id);
        IList<Fornecedor> ObterTodos();
    }
}