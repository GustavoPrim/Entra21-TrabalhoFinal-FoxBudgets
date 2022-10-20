using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Estoque
{
    public class EstoqueCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [RegularExpression(@"^[a-zãçA-Z''-'\s]{3,30}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(40, ErrorMessage = "{0} deve conter no máximo {1}")]
        public decimal Valor { get; set; }

        [Display(Name = "Item")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        public int Item { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public int Quantidade { get; set; }
    }
}
