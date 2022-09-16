using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;

namespace Aplicacao.Administradores
{
    internal interface IAdministradorServico
    {
        Adm Cadastrar(AdministradorCadastrarViewModel viewModel);
        bool Editar(AdministradorEditarViewModel viewModel);
        bool Apagar(int id);
        Adm? ObterPorId(int id);
        IList<Adm> ObterTodos();
    }
}