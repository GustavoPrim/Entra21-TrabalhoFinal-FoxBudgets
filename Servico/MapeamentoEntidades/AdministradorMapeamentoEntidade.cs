using Repositorio.Entidades;
using Servico.Servicos;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    public class AdministradorMapeamentoEntidade : IAdministradorMapeamentoEntidade
    {
        public void AtualizarCom(Administrador administrador, AdministradorEditarViewModel administradorEditarViewModel)
        {
            administrador.Nome = administradorEditarViewModel.Nome;
            administrador.Cpf = administradorEditarViewModel.Cpf;
            administrador.DataNascimento = administradorEditarViewModel.DataNascimento;
            administrador.Endereco = administradorEditarViewModel.Endereco;
            administrador.Email = administradorEditarViewModel.Email;
            administrador.Telefone = administradorEditarViewModel.Telefone;
            administrador.Senha = administradorEditarViewModel.Senha;
        }

        public Administrador ConstruirCom(AdministradorCadastrarViewModel viewModel)
        {
            return new Administrador
            {
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Email = viewModel.Email,
                DataNascimento = viewModel.DataNascimento,
                Cpf = viewModel.Cpf,
                Endereco = viewModel.Endereco,
                Senha = viewModel.Senha.GerarHash()
            };
        }
    }
}
