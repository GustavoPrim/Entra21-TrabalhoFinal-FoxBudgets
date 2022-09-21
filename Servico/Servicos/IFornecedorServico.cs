using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos
{
    public interface IFornecedorServico
    {
        Fornecedor BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Fornecedor CadastrarFornecedor(FornecedorCadastrarViewModel viewModel);
        bool Editar(FornecedorEditarViewModel viewModel);
        Fornecedor? ObterPorId(int id);
        IList<Fornecedor> ObterTodos();
    }
}