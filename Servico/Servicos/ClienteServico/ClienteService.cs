using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels.ClienteViewModels;

namespace Servico.Servicos.ClienteServico
{
    public class ClienteService 
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(OrcamentoContexto contexto)
        {
            //_clienteRepositorio = new ClienteRepositorio(contexto);
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
        }

        public void Cadastrar(ClienteCadastrarViewModel clienteCadastrarViewModel)
        {
            var cliente = new Cliente();
            cliente.Cpf = clienteCadastrarViewModel.Cpf;
            cliente.DataNascimento = clienteCadastrarViewModel.DataNascimento;
            cliente.Endereco = clienteCadastrarViewModel.Endereco;
            cliente.Email = clienteCadastrarViewModel.Email;
            cliente.Telefone = clienteCadastrarViewModel.Telefone;
            cliente.Cnpj = clienteCadastrarViewModel.Cnpj;
        }

        public void Editar(ClienteEditarViewModel clienteEditarViewModel)
        {
            var cliente = new Cliente();
            cliente.Cpf = clienteEditarViewModel.Cpf;
            cliente.DataNascimento = clienteEditarViewModel.DataNascimento;
            cliente.Endereco = clienteEditarViewModel.Endereco;
            cliente.Email = clienteEditarViewModel.Email;
            cliente.Telefone = clienteEditarViewModel.Telefone;
            cliente.Cnpj = clienteEditarViewModel.Cnpj;

            //_clienteRepositorio.Atualizar(cliente);
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _clienteRepositorio.ObterPorId(id);

            return cliente;
        }

        //public List<Cliente> ObterTodos()
        //{
        //    var clienteDoBanco = _clienteRepositorio.ObterTodos();

        //    //return clienteDoBanco;
        //}
    }
}