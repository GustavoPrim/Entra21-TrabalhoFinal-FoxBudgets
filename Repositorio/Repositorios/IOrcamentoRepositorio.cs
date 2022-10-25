using Repositorio.Entidades;

namespace Repositorio.Repositorios;

public interface IOrcamentoRepositorio
{
    Orcamento Cotar(Orcamento orcamentoMaterial);
    void Editar(Orcamento orcamentoMaterial);
    Orcamento ObterPorId(int id);
    List<Orcamento> ObterTodos();
    bool Apagar(int id);
    Orcamento? ObterPorClienteId(int idCliente);
    void CrirOuAtualizar(Orcamento orcamento);
    Orcamento? ObterPorOrcamentoCliente(int clienteId, Estoque material);
    List<OrcamentoMaterial> EstoqueIdMaterial(OrcamentoMaterial[] listaOrcamnento, int materialId);
}