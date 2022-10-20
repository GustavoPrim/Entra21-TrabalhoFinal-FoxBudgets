using Repositorio.Entidades;

namespace Servico.ViewModels.Estoque
{
    public class EstoqueItemIndexViewModel
    {
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Material Material { get; set; }
        public int EstoqueMaterialId { get; set; }

    }
}
