using Repositorio.Entidades;
using Servico.ViewModels.Estoque;
using Servico.ViewModels.Fornecedores;
using Servico.ViewModels.Orcamentos;

namespace Servico.Servicos
{
    public interface IFornecedorServico
    {
        Estoque Adicionar(EstoqueCadastrarViewModel viewModel, int fornecedorId);
        Fornecedor BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Fornecedor CadastrarFornecedor(FornecedorCadastrarViewModel viewModel);
        bool Editar(FornecedorEditarViewModel viewModel);
        Fornecedor? ObterPorId(int id);
        IList<Fornecedor> ObterTodos();

        List<OrcamentoItemIndexViewModel> ObterItensOrcamentoAtual(int idUsuarioLogado);
    }
}