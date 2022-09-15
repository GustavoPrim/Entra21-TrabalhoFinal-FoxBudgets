using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoViewModels
{
    public interface IClienteMapeamentoViewModel
    {
        ClienteEditarViewModel ConstruirCom(ClienteEditarViewModel cliente);
    }
}