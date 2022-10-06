using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Orcamentos
{
    public class OrcamentoCadastrarViewModel
    {
        [Display(Name = "Item")]
        [Required(ErrorMessage = "{0} deve ser selecionado")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        public int Item { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1}")]
        public int Quantidade { get; set; }

        [Display(Name = "DataOrcamento")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        public DateTime DataOrcamento { get; set; }

    }
}
