using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades
{
    public class Orcamento
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime DataOrcamento { get; set; }
        public string Item { get; set; } //ver como puxar do banco de dados o material, só criei essa propriedade pra ter um norte
        public int Quantidade { get; set; }
        public double ValorUnitarioItem { get; set; }
        public double ValorTotalItem { get; set; }
        public double ValorTotalOrcamento { get; set; }
    }
}
