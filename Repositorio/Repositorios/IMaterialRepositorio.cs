using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IMaterialRepositorio
    {
        public Material Cadastrar(Material material);
        public IList<Material> ObterTodos();
        public void Editar(Material materialParaAlterar);
        public bool Apagar(int id);
        Material? ObterPorId(int id);
    }
}