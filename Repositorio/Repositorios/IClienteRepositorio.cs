using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio
    {
        Cliente Cadastrar(Cliente cliente);
        IList<Cliente> ObterTodos();
        public void Atualizar(Cliente clienteParaAlterar);
        void Editar(Cliente viewModel);
        bool Apagar(int id);
        Cliente ObterPorId(int Id);
    }
}