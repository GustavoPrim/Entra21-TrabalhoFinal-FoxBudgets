using Servico.ViewModels.Administradores;

namespace Aplicacao.Administrador
{
    internal interface IAdministradorServico
    {
        void Cadastrar(AdministradorCadastrarViewModel administradorCadastrarViewModel);
        void Editar(AdministradorCadastrarViewModel administradorEditarViewModel);
        void Apagar(int id);
        Administrador ObterPorId(int id);
        List<Administrador> ObterTodos();
        IList<>
    }
}