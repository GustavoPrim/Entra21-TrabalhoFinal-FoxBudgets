using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IAdministradorRepositorio
    {
        bool Apagar(int id);
        Administrador Cadastrar(Administrador administrador);
        void Editar(Administrador administrador);
        Administrador ObterPorId(int id);
        IList<Administrador> ObterTodos();
    }
}