using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoEntidades
{
    internal interface IAdministradorMapeamentoEntidade
    {
        Administrador ConstruirCom(AdministradorCadastrarViewModel viewModel, string caminho);
    }
}
