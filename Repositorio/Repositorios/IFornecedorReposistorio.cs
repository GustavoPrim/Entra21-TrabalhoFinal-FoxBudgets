using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IFornecedorReposistorio
    {
        void Cadastrar(Fornecedor fornecedor);
        List<Fornecedor> ObterTodos();
        void Atualizar(Fornecedor fornecedorParaAlterar);
        void Apagar(int id);
        Fornecedor ObterPorId(int id);
    }
}