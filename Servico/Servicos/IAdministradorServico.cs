using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Administradores;

namespace Aplicacao.Administradores
{
    internal interface IAdministradorServico
    {
        Administrador Cadastrar(AdministradorCadastrarViewModel viewModel,string caminhoArquivos);
        void Editar(AdministradorCadastrarViewModel administradorEditarViewModel);
        bool Apagar(int id);
        Administrador? ObterPorId(int id);
        List<Administrador> ObterTodos();
        IList<Administrador> ObterTodosSelect2();
    }
}