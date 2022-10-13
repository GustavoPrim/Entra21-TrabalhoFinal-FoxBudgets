using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades
{
	public class ClienteMapeamentoEntidade : IClienteMapeamentoEntidade
    {
        public void AtualizarCampos(Cliente cliente, ClienteEditarViewModel viewModel, string caminho)
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

            if (!string.IsNullOrEmpty(caminho))
                cliente.CaminhoArquivo = caminho;
        }

        public Cliente ConstruirCom(CadastrarUsuarioViewModel viewModel, string caminho)
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
                Senha = viewModel.Senha.GerarHash(),
                CaminhoArquivo = caminho
            };
        }
    }
}
