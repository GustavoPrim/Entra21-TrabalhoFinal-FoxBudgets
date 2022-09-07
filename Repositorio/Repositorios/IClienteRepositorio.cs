using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        public void Cadastrar(Cliente cliente);
        public IList<Cliente> ObterTodos();
        public void Atualizar(Cliente clienteParaAlterar);
        public void Apagar(int id);
        Cliente ObterPorId(int Id);
    }
}