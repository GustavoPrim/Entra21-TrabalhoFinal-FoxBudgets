using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Clientes
{
    public class ClienteCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public string Nome { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(14, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string Cpf { get; set; }

        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(14, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string Cnpj { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1} caracter")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [EmailAddress(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve ter no mínimo {1} caracteres")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(13, ErrorMessage = "{0} deve conter no mínimo {1} dígitos")]
        [MaxLength(13, ErrorMessage = "{0} deve conter no máximo {1} dígitos")]
        public string Telefone { get; set; }
    }
}