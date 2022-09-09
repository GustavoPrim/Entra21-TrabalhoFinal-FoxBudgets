using Repositorio.Entidades;
using Servico.ViewModels.ClienteViewModels;

namespace Servico.Servicos.ClienteServico
{
    public interface IClienteService
    {
        void Cadastrar(ClienteCadastrarViewModel clienteCadastrarViewModel);
        IList<Cliente> ObterTodos();
        void Editar(ClienteEditarViewModel clienteEditarViewModel);
        void Apagar(int id);
        Cliente ObterPorId(int id);
    }
}