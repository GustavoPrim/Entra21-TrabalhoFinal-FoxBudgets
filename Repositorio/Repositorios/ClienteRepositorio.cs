using Repositorio.BancoDados;
using Repositorio.Entidades;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteContexto _contexto;

        public ClienteRepositorio(ClienteContexto contexto)
        {
            _contexto = contexto;
        }

        public void Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();
        }

        public void Atualizar(Cliente clienteParaAlterar)
        {
            var cliente = _contexto.Clientes.Where(x => x.Id == clienteParaAlterar.Id).FirstOrDefault();

            cliente.Cpf = clienteParaAlterar.Cpf;
            cliente.DataNascimento = clienteParaAlterar.DataNascimento;
            cliente.Endereco = clienteParaAlterar.Endereco;
            cliente.Email = clienteParaAlterar.Email;
            cliente.Telefone = clienteParaAlterar.Telefone;
            cliente.Cnpj = clienteParaAlterar.Cnpj;

            _contexto.Update(cliente);
            _contexto.SaveChanges();
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