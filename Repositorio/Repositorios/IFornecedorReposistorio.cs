using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IFornecedorReposistorio
    {
        Fornecedor BuscarPorLogin(string login);
        bool Apagar(int id);
        Fornecedor Cadastrar(Fornecedor fornecedor);
        void Editar(Fornecedor fornecedorParaAlterar);
        Fornecedor ObterPorId(int id);
        IList<Fornecedor> ObterTodos();
    }
}