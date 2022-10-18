using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Orcamentos
{
    public class OrcamentoCadastrarViewModel
    {
        [Display(Name = "Item")]
        [Required(ErrorMessage = "{0} deve ser selecionado")]
        public int Item { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "{0} deve ser preenchida")]
        public int Quantidade { get; set; }
    }
}
