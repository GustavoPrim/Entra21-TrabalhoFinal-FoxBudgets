using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;
//namespace Repositorio.entidades;

namespace Aplicacao.Administradores
{
    internal interface IAdministradorServico
    {
        void Cadastrar(AdministradorCadastrarViewModel administradorCadastrarViewModel);
        void Editar(AdministradorCadastrarViewModel administradorEditarViewModel);
        void Apagar(int id);
        Administrador ObterPorId(int id);
        List<Administrador> ObterTodos();
        IList<SelectViewModel> ObterTodosSelect2();
    }
}