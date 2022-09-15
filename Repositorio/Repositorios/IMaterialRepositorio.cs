using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IMaterialRepositorio
    {
        bool Apagar(int id);
        Material CadastrarMateriais(Material material);
        void EditarMateriais(Material material);
        Material? ObterPorId(int id);
        IList<Material> ObterTodos();
    }
}