using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        public void Cadastrar(Cliente cliente);
        public List<Cliente> ObterTodos();
        public void Editar();
        public void Apagar(int id);
        Cliente ObterPorId(int Id);
    }
}