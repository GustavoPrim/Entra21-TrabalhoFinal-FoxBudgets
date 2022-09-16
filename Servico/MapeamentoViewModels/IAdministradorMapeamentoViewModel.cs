using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.MapeamentoViewModels
{
    public interface IAdministradorMapeamentoViewModel
    {
        AdministradorEditarViewModel ConstruirCom(Administrador administrador);
    }
}