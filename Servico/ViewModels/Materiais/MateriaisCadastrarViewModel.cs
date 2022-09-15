using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Materiais;
public class MateriaisViewModel
{
    [Display(Name = nameof(Nome))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
    [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
    public string Nome { get; set; }

    [Display(Name = nameof(Sku))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(8, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
    [MaxLength(12, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
    public string Sku { get; set; }

    [Display(Name = nameof(DataValidade))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [DataType(DataType.Date)]
    public DateTime DataValidade { get; set; }

    [Display(Name = nameof(Descricao))]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
    public string Descricao { get; set; }

    [Display(Name = "Fornecedor")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int? FornecedorId { get; set; }
}