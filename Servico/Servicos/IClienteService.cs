using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Servico.Servicos
{
    public interface IClienteService
    {
        Cliente BuscarPorLogin(string login, string senha);
        bool Apagar(int id);
        Cliente Cadastrar(CadastrarUsuarioViewModel viewModel, string caminhoArquivo);
        bool Editar(ClienteEditarViewModel viewModelEditar, string caminhoArquivo);
        bool VerificarEmail(string email);
        Cliente AtualizarVerificarEmail(int id);
        Cliente? ObterPorId(int id);
        IList<Cliente> ObterTodos();
    }
}