using Repositorio.Entidades;
using Servico.ViewModels.Clientes;

namespace Servico.Servicos
{
    public interface IClienteService
    {
        //Cliente BuscarPorLogin(string login);
        bool Apagar(int id);
        Cliente Cadastrar(ClienteCadastrarViewModel viewModel);
        bool Editar(ClienteEditarViewModel viewModel);
        Cliente? ObterPorId(int id);
        IList<Cliente> ObterTodos();
    }
}