using Repositorio.Entidades;
using Servico.ViewModels;

namespace Repositorio.Repositorios
{
    public interface IAdministradorRepositorio
    {
        Administrador? BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Administrador Cadastrar(Administrador administrador);
        void Editar(Administrador administrador);
        Administrador ObterPorId(int id);
        IList<Administrador> ObterTodos();
        //Administrador AlterarSenha(AlterarSenhaViewModel alterarSenha);
    }
}