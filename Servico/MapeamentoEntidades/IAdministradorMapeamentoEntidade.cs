using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    internal interface IAdministradorMapeamentoEntidade
    {
        Administrador ConstruirCom(AdministradorCadastrarViewModel viewModel);
        void AtualizarCom(Administrador administrador, AdministradorEditarViewModel viewModel);
    }
}
