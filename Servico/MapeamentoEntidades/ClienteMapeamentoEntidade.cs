using Repositorio.Entidades;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades
{
    public class ClienteMapeamentoEntidade : IClienteMapeamentoEntidade
    {
        public void AtualizarCampos(Cliente cliente, ClienteEditarViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Cliente ConstruirCom(ClienteCadastrarViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}