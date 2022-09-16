using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    internal interface IAdministradorMapeamentoEntidade
    {
        Adm ConstruirCom(AdministradorCadastrarViewModel viewModel);
        void AtualizarCom(Adm administrador, AdministradorEditarViewModel administradorEditarViewModel);
    }
}