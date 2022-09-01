using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteContexto _contexto;
        public void Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();
        }

        public void Editar()
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}