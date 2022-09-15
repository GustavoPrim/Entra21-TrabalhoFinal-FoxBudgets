using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.Servicos
{
    public interface IAdministradorServico
    {
        Adm Cadastrar(AdministradorCadastrarViewModel viewModel);
        bool Editar(AdministradorEditarViewModel viewModel);
        bool Apagar(int id);
        Adm? ObterPorId(int id);
        IList<Adm> ObterTodos();
    }
}