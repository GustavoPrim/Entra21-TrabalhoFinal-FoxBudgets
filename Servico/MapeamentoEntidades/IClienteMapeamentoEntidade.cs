using Repositorio.Entidades;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Servico.MapeamentoEntidades;

public interface IClienteMapeamentoEntidade
{
    Cliente ConstruirCom(CadastrarUsuarioViewModel viewModel, string caminho);
    void AtualizarCampos(Cliente cliente, ClienteEditarViewModel viewModel, string caminho);
}