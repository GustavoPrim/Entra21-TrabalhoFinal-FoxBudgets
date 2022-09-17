using Repositorio.Entidades;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades
{
    public class ClienteMapeamentoEntidade : IClienteMapeamentoEntidade
    {
        public void AtualizarCampos(Cliente cliente, ClienteEditarViewModel viewModel)
        {
            cliente.Nome = viewModel.Nome;
            cliente.Cpf = viewModel.Cpf;
            cliente.DataNascimento = viewModel.DataNascimento;
            cliente.Endereco = viewModel.Endereco;
            cliente.Email = viewModel.Email;
            cliente.Telefone = viewModel.Telefone;
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
                Endereco = viewModel.Endereco,
            };
        }
    }
}
