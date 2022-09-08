using Repositorio.Entidades;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades
{
    public interface IClienteMapeamentoEntidade
    {
        Cliente ConstruirCom(ClienteCadastrarViewModel viewModel, string caminho);
        void AtualizarCom(Cliente cliente, ClienteEditarViewModel clienteEditarViewModel, string caminho);
    }
}