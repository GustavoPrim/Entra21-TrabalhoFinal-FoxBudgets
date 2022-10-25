namespace Servico.ViewModels.Orcamentos
{
    public class OrcamentoMaterialViewModel
    {
        public string Item { get; set; }
        public int Quantidade { get; set; }
        public List<OrcamentoFornecedorViewModel> Fornecedores { get; set; } = new List<OrcamentoFornecedorViewModel>();

    }
}
