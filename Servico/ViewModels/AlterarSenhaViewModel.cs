using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels
{
    public class AlterarSenhaViewModel
    {
        [Display(Name = "SenhaAtual")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"^[a-zãçA-Z''-'\s]{3,100}$", ErrorMessage =
         "Números e caracteres especiais não são permitidos no nome!")]
        public string SenhaAtual { get; set; }

        [Display(Name = "NovaSenha")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"^[a-zãçA-Z''-'\s]{3,100}$", ErrorMessage =
         "Números e caracteres especiais não são permitidos no nome!")]
        public string NovaSenha { get; set; }

        [Display(Name = "ConfirmarSenha")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não correspondem")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        public string ConfirmarSenha { get; set; }
    }
}
