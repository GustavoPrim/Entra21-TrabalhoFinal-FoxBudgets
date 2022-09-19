namespace Repositorio.Entidades
{
    public class OrcamentoMaterial : EntidadeBase
    {
        public int OrcamentoId { get; set; }
        public int MaterialId { get; set; }
        public int Quantidade { get; set; }

        public Orcamento Orcamento { get; set; }
        public Material Material { get; set; }
    }
}
