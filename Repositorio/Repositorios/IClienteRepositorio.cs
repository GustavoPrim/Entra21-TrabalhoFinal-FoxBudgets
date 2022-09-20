using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        Cliente BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Cliente Cadastrar(Cliente cliente);
        void Editar(Cliente cliente);
        Cliente? ObterPorId(int id);
        IList<Cliente> ObterTodos();
    }
}