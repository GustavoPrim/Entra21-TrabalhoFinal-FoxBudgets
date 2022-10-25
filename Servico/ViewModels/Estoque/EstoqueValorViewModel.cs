using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Estoque;

public class EstoqueCadastrarViewModel
{
    [Display(Name = "Valor")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public double Valor { get; set; }

    [Display(Name = "Item")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int Item { get; set; }

    [Display(Name = "Quantidade")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int Quantidade { get; set; }
}