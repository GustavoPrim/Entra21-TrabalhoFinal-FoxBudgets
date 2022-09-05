using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IAdministradorRepositorio
    {
        void Cadastrar(Administrador administrador);
        List<Administrador> ObterTodos();
        void Atualizar(Administrador administradorParaAlterar);
        void Apagar(int id);
        Administrador ObterPorId(int id);
    }
}