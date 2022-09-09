using Repositorio.BancoDados;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.MapeamentoEntidades;
using Servico.ViewModels.ClienteViewModels;

namespace Servico.Servicos.ClienteServico;

public class ClienteService : IClienteService
{

    private readonly IClienteRepositorio _clienteRepositorio;
    private readonly IClienteMapeamentoEntidade _mapeamentoEntidade;
    public ClienteService(
    IClienteRepositorio clienteRespositorio,
    IClienteMapeamentoEntidade mapeamentoEntidade)
    {
        _clienteRepositorio = clienteRespositorio;
        _mapeamentoEntidade = mapeamentoEntidade;
    }
    public bool Apagar(int id) =>
        _clienteRepositorio.Apagar(id);
    public Cliente Cadastrar(ClienteCadastrarViewModel viewModel)
    {
        var cliente = _mapeamentoEntidade.ConstruirCom(viewModel);
        _clienteRepositorio.Cadastrar(cliente);
        return cliente;
    }

    public bool Editar(ClienteEditarViewModel viewModel)
    {
        var cliente = _clienteRepositorio.ObterPorId(viewModel.Id);
        if (cliente == null)
            return false;

        _mapeamentoEntidade.AtualizarCampos(cliente, viewModel);
        _clienteRepositorio.Editar(cliente);
        return true;
    }
 
    private void ApagarArquivoAntigo(string caminhoPastaImagens, string arquivoAntigo)
    {
        var caminhoArquivoAntigo = Path.Join(caminhoPastaImagens, arquivoAntigo);

        if (File.Exists(caminhoArquivoAntigo))
            File.Delete(caminhoArquivoAntigo);
    }
    public Cliente ObterPorId(int id) =>
    _clienteRepositorio.ObterPorId(id);

    public IList<Cliente> ObterTodos() =>
    _clienteRepositorio.ObterTodos();
}
