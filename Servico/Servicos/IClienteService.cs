using Repositorio.Entidades;
using Servico.ViewModels;

namespace Servico.Servicos
{
    public interface IClienteService
    {
        void Cadastrar(ClienteCadastrarViewModel clienteCadastrarViewModel);
        List<Cliente> ObterTodos();
        void Editar(ClienteEditarViewModel clienteEditarViewModel);
        void Apagar(int id);
        void ObterPorId(int id);
    }
}