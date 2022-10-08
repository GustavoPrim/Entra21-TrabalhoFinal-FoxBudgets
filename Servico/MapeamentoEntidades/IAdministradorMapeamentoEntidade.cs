    using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    public interface IAdministradorMapeamentoEntidade
    {
        Administrador ConstruirCom(AdministradorCadastrarViewModel viewModel, string caminho);
        void AtualizarCom(Administrador administrador, AdministradorEditarViewModel administradorEditarViewModel, string caminho);
    }
}