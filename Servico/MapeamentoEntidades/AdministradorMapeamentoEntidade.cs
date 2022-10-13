using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
	public class AdministradorMapeamentoEntidade : IAdministradorMapeamentoEntidade
    {
        public void AtualizarCom(Administrador administrador, AdministradorEditarViewModel administradorEditarViewModel, string caminho)
        {
            administrador.Nome = administradorEditarViewModel.Nome;
            administrador.Cpf = administradorEditarViewModel.Cpf;
            administrador.DataNascimento = administradorEditarViewModel.DataNascimento;
            administrador.Endereco = administradorEditarViewModel.Endereco;
            administrador.Email = administradorEditarViewModel.Email;
            administrador.Telefone = administradorEditarViewModel.Telefone;
            administrador.Login = administradorEditarViewModel.Login;
            administrador.Senha = administradorEditarViewModel.Senha;

            if (!string.IsNullOrEmpty(caminho))
                administrador.CaminhoArquivo = caminho;
        }

        public Administrador ConstruirCom(AdministradorCadastrarViewModel viewModel, string caminho)
        {
            return new Administrador
            {
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Email = viewModel.Email,
                DataNascimento = viewModel.DataNascimento,
                Cpf = viewModel.Cpf,
                Endereco = viewModel.Endereco,
                Login = viewModel.Login,
                Senha = viewModel.Senha.GerarHash(),
                CaminhoArquivo = caminho
            };
        }
    }
}