namespace Repositorio.Entidades
 
 public class Orcamento : EntidadeBase
    {

        public int Numero { get; set; }
        public DateTime DataOrcamento { get; set; }
        public string Item { get; set; } //ver como puxar do banco de dados o material, só criei essa propriedade pra ter um norte
        public int Quantidade { get; set; }
        public double ValorUnitarioItem { get; set; }
        public double ValorTotalItem { get; set; }
        public double ValorTotalOrcamento { get; set; }
        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public IList<OrcamentoMaterial> OrcamentoMateriais { get; set; }



{
   

