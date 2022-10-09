using Repositorio.Entidades;
using Servico.ViewModels.Fornecedores;

namespace Servico.Servicos
{
    public interface IFornecedorServico
    {
        Fornecedor BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Fornecedor CadastrarFornecedor(FornecedorCadastrarViewModel viewModel, string caminhoArquivo);
        bool Editar(FornecedorEditarViewModel viewModel, string caminhoArquivo);
        Fornecedor? ObterPorId(int id);
        IList<Fornecedor> ObterTodos();
    }
}