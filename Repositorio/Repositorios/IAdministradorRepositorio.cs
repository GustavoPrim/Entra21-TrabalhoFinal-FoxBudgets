using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IAdministradorRepositorio
    {
        Adm BuscarPorLogin(string login);
        bool Apagar(int id);
        Adm Cadastrar(Adm administrador);
        void Editar(Adm administrador);
        Adm ObterPorId(int id);
        IList<Adm> ObterTodos();
    }
}