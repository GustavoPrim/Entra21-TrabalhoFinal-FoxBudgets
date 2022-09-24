namespace Repositorio.Entidades
{
    public class Material : EntidadeBase
    {
        public string Nome { get; set; }
        public string Sku { get; set; }
        public DateTime DataValidade { get; set; }
        public string Descricao { get; set; }
        public bool PossuiDataValidade { get; set; }

        public IList<Estoque> Estoques { get; set; }
        public IList<OrcamentoMaterial> OrcamentoMateriais { get; set; }
    }
}