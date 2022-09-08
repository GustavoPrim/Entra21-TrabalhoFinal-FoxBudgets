using Repositorio.Entidades;
using Servico.ViewModels.Clientes;

namespace Servico.Servicos
{
    public interface IClienteService
    {
        bool Apagar(int id);
        Cliente Cadastrar(ClienteCadastrarViewModel viewModel);
        bool Editar(ClienteEditarViewModel viewModel);
        Cliente? ObterPorId(int id);
        IList<Cliente> ObterTodos();
    }
}