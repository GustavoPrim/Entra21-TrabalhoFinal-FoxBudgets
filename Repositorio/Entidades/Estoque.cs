using Repositorio.Enuns;

namespace Repositorio.Entidades
{
    public class Estoque : EntidadeBase
    {
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int MaterialId { get; set; }
        public int FornecedorId { get; set; }
        public EstoqueTipo Tipo { get; set; }

        public Material Material { get; set; }
        public Fornecedor Fornecedor{ get; set; }
        public IList<Estoque> EstoqueMaterial { get; set; }
    }
}
