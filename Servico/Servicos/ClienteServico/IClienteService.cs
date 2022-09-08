using Repositorio.Entidades;

namespace Servico.Servicos.ClienteServico
{
    public interface IClienteService
    {
        void Cadastrar(ClienteCadastrarViewModel clienteCadastrarViewModel);
        List<Cliente> ObterTodos();
        void Editar(ClienteEditarViewModel clienteEditarViewModel);
        void Apagar(int id);
        Cliente ObterPorId(int id);
    }
}