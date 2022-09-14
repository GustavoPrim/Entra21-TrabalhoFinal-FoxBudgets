using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IMaterialRepositorio
    {
        bool Apagar(int id);
        Material Cadastrar(Material material);
        void Editar(Material material);
        Material? ObterPorId(int id);
        IList<Material> ObterTodos();
    }
}