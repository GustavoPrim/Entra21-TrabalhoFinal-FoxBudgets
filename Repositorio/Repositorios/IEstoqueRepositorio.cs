using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IEstoqueRepositorio
    {
        bool Apagar(int id);
        Estoque CadastrarValor(Estoque valor);
        Estoque Cadastrar(Estoque quantidade);
        Estoque ObterPorId(int id);
        IList<Estoque> ObterTodos();
        void Editar(Estoque estoque);
        void CriarOuAtualizar(Estoque estoque);
        List<Estoque> ObterTodosPorFornecedorId(int idFornecedor);
        Estoque? ObterPorFornecedorId(int fornecedorId, int item);
    }
}
