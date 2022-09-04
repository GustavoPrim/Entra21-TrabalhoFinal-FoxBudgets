using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels;

namespace Servico.Servicos
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteService(ClienteContexto contexto)
        {
            _clienteRepositorio = new ClienteRepositorio(contexto);
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
            cliente.DataFundacao = clienteCadastrarViewModel.DataFundacao;
            cliente.EnderecoConstrutora = clienteCadastrarViewModel.EnderecoConstrutora;
            cliente.EmailConstrutora = clienteCadastrarViewModel.EmailConstrutora;
            cliente.TelefoneComercial = clienteCadastrarViewModel.TelefoneComercial;
            cliente.Crea = clienteCadastrarViewModel.Crea;
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
            cliente.DataFundacao = clienteEditarViewModel.DataFundacao;
            cliente.EnderecoConstrutora = clienteEditarViewModel.EnderecoConstrutora;
            cliente.EmailConstrutora = clienteEditarViewModel.EmailConstrutora;
            cliente.TelefoneComercial = clienteEditarViewModel.TelefoneComercial;
            cliente.Crea = clienteEditarViewModel.Crea;

            _clienteRepositorio.Atualizar(cliente);
        }

        public void ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}