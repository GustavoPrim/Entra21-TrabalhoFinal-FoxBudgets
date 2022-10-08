using Repositorio.Entidades;
using Servico.ViewModels.Administradores;

namespace Servico.Servicos
{
    public interface IAdministradorServico
    {
        Administrador BuscarPorLogin(string login, string senha);
        Administrador Cadastrar(AdministradorCadastrarViewModel viewModel, string caminhoArquivos);
        bool Editar(AdministradorEditarViewModel viewModel, string caminhoArquivos);
        bool Apagar(int id);
        Administrador? ObterPorId(int id);
        IList<Administrador> ObterTodos();
    }
}