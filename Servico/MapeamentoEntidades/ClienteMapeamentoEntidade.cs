using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades
{
	public class ClienteMapeamentoEntidade : IClienteMapeamentoEntidade
    {
        public void AtualizarCampos(Cliente cliente, ClienteEditarViewModel viewModel)
        {
            cliente.Nome = viewModel.Nome;
            cliente.Cpf = viewModel.Cpf;
            cliente.Cnpj = viewModel.Cnpj;
            cliente.DataNascimento = viewModel.DataNascimento;
            cliente.Endereco = viewModel.Endereco;
            cliente.Email = viewModel.Email;
            cliente.Telefone = viewModel.Telefone;
            cliente.Login = viewModel.Login;
            cliente.Senha = viewModel.Senha;
        }

        public Cliente ConstruirCom(ClienteCadastrarViewModel viewModel)
        {
            return new Cliente
            {
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Email = viewModel.Email,
                DataNascimento = viewModel.DataNascimento,
                Cpf = viewModel.Cpf,
                Cnpj = viewModel.Cnpj,
                Endereco = viewModel.Endereco,
                Login = viewModel.Login,
                Senha = viewModel.Senha.GerarHash()
            };
        }
    }
}
