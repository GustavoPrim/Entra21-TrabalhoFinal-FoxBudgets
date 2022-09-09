using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Administradores
{
    public class AdministradorCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public string Nome { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(11, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string Cpf { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1} caracter")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve ter no mínimo {1} caracteres")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [MinLength(8, ErrorMessage = "{0} deve conter no mínimo {1} caracteres")]
        public int Telefone { get; set; }
    }
}