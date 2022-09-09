using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Fornecedores
{
    public class FornecedorCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(4, ErrorMessage = "{0} deve conter pelo menos {1} caracteres")]
        [MaxLength(20, ErrorMessage = "{0} pode conter apenas {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(14, ErrorMessage = "{0} deve conter 14 dígitos!")]
        [MaxLength(14, ErrorMessage = "{0} deve conter 14 dígitos!")]
        public string Cnpj { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(8, ErrorMessage = "{0} deve conter pelo menos {1} caracteres!" )]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string Endereco { get; set; }

        [Display(Name = "Data de fundação")]
        [Required(ErrorMessage = "{0} deve ser preenchida!")]
        [MinLength(8, ErrorMessage = "{0} deve conter {1} caracteres!")]
        [MaxLength(8, ErrorMessage = "{0} deve conter {1} caracteres!")]
        public DateTime DataFundacao { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "{0} deve ser especificada!")]
        [MinLength(5, ErrorMessage = "{0} deve conter pelo menos {1} caracteres!")]
        [MaxLength(20, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string Categoria { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(6, ErrorMessage = "{0} deve conter pelo menos {1} caracteres!")]
        [MaxLength(25, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(10, ErrorMessage = "{0} deve conter pelo menos {1} caracteres!")]
        [MaxLength(11, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string Telefone { get; set; }
    }
}
