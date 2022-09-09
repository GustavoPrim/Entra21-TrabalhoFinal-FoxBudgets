using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;

namespace Aplicacao.Administradores
{
    internal interface IAdministradorServico
    {
        Administrador Cadastrar(AdministradorCadastrarViewModel viewModel);
        bool Editar(AdministradorEditarViewModel viewModel);
        bool Apagar(int id);
        Administrador? ObterPorId(int id);
        IList<Administrador> ObterTodos();
    }
}