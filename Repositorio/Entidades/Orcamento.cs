namespace Repositorio.Entidades
{
    public class Orcamento : EntidadeBase
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public IList<OrcamentoMaterial> OrcamentoMateriais { get; set; }
    }
}
