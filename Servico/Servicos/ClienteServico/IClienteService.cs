using Repositorio.Entidades;
using Servico.ViewModels.ClienteViewModels;

namespace Servico.Servicos.ClienteServico
{
    public interface IClienteService
    {
        Cliente Cadastrar(ClienteCadastrarViewModel clienteCadastrarViewModel);
        IList<Cliente> ObterTodos();
        bool Editar(ClienteEditarViewModel clienteEditarViewModel);
        bool Apagar(int id);
        Cliente ObterPorId(int id);
    }
}