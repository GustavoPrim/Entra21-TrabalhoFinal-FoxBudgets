using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    public class AdministradorMapeamentoEntidade : IAdministradorMapeamentoEntidade
    {
        public void AtualizarCom(Adm administrador, AdministradorEditarViewModel administradorEditarViewModel)
        {
            administrador.Nome = administradorEditarViewModel.Nome;
            administrador.Cpf = administradorEditarViewModel.Cpf;
            administrador.DataNascimento = administradorEditarViewModel.DataNascimento;
            administrador.Endereco = administradorEditarViewModel.Endereco;
            administrador.Email = administradorEditarViewModel.Email;
            administrador.Telefone = administradorEditarViewModel.Telefone;
        }

        public Adm ConstruirCom(AdministradorCadastrarViewModel viewModel)
        {
            return new Adm
            {
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Email = viewModel.Email,
                DataNascimento = viewModel.DataNascimento,
                Cpf = viewModel.Cpf,
                Endereco = viewModel.Endereco
            };
        }
    }
}
