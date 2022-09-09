using Repositorio.BancoDados;
using Repositorio.Entidades;
using System.Data.Entity;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio 
    {
        private readonly OrcamentoContexto _contexto;

        public ClienteRepositorio(OrcamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public bool Apagar(int id)
        {
            var cliente = _contexto.Clientes
                .FirstOrDefault(x => x.Id == id);

            if (cliente == null)
                return false;

            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();

            return true;
        }

        public void Cadastrar(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();
        }

        public void Editar(Cliente clienteParaAlterar)
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

        public Cliente? ObterPorId(int id) => 
            _contexto.Clientes.FirstOrDefault(x => x.Id == id);
        
        public IList<Cliente> ObterTodos() => 
            _contexto.Clientes
                .Include(x => x.Cpf)
                .Include(x => x.Cnpj)
                .Include(x => x.DataNascimento)
                .Include(x => x.Email)
                .Include(x => x.Telefone)
                .ToList();

        //void IClienteRepositorio.Apagar(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}