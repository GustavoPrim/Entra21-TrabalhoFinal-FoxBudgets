using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        Cliente BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Cliente Cadastrar(Cliente cliente);
        void Editar(Cliente clienteParaAlterar);
        Cliente? GetByEmailAndPassword(string email, string password);
        IList<Cliente>? GetActiveUsers();
        Cliente? ObterPorId(int id);
        IList<Cliente> ObterTodos();
    }
}