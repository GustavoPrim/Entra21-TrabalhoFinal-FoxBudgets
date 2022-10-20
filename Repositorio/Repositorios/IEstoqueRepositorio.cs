using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IEstoqueRepositorio
    {
        bool Apagar(int id);
        Estoque CadastrarValor(Estoque valor);
        Estoque CadastrarQuantidade(Estoque quantidade);
        Estoque ObterPorId(int id);
        IList<Estoque> ObterTodos();
        void Editar(Estoque estoque);
        void CrirOuAtualizar(Estoque estoque);
        Estoque? ObterPorFornecedorId(int idFornecedor);

    }
}
