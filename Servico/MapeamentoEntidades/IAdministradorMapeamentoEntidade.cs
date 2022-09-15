using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    public interface IAdministradorMapeamentoEntidade
    {
        Adm ConstruirCom(AdministradorCadastrarViewModel viewModel);
        void AtualizarCom(Adm administrador, AdministradorEditarViewModel administradorEditarViewModel);
    }
}