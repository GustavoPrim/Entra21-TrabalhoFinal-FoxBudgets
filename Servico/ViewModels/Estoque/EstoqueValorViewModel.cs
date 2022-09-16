using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Estoque
{
    public class EstoqueCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public string Nome { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(40, ErrorMessage = "{0} deve conter no máximo {1}")]
        public double Valor { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public int Quantidade { get; set; }
    }
}
