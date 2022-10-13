using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades;

public interface IClienteMapeamentoEntidade
{
    Cliente ConstruirCom(CadastrarUsuarioViewModel viewModel);
    void AtualizarCampos(Cliente cliente, ClienteEditarViewModel viewModel);
}