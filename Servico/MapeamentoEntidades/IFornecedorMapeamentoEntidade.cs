using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.MapeamentoEntidades
{
    public interface IFornecedorMapeamentoEntidade
    {
        bool Apagar(int id);
        Fornecedor Cadastrar(FornecedorCadastrarViewModel viewModel);
        bool Editar(FornecedorEditarViewModel viewModel);
        Fornecedor? ObterPorId(int id);
        IList<Fornecedor> ObterTodos();
    }
}