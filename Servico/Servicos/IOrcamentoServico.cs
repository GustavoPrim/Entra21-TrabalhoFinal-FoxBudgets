using Repositorio.Entidades;
using Servico.ViewModels.Orcamentos;

namespace Servico.Servicos;

public interface IOrcamentoServico
{
    Orcamento Cotar(OrcamentoCadastrarViewModel viewModel, int clienteId);
    bool Editar(OrcamentoEditarViewModel viewModel);
    Orcamento ObterPorId(int id);
    List<Orcamento> ObterTodos();
    bool Apagar(int id);
    List<OrcamentoItemIndexViewModel> ObterItensOrcamentoAtual(int idUsuarioLogado);
}