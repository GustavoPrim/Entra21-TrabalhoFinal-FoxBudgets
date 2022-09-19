using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.ViewModels.Orcamentos
{
    public class OrcamentoCadastrarViewModel
    {
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1}")]
        public int Quantidade { get; set; }

        [Display(Name = "DataOrcamento")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        public DateTime DataOrcamento { get; set; }

        [Display(Name = "Item")]
        [Required(ErrorMessage = "{0} deve ser selecionado")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        public int Item { get; set; }
    }
}
