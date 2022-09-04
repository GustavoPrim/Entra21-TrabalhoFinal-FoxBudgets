using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Administradores
{
    internal class AdministradorCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public string Nome { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(11, ErrorMessage = "{0} deve contér {1} caracteres")]
        public string Cpf { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [Required(ErrorMessage = "{0} deve estar no formato dd/MM/yyyy")]
        [DataType(DataType.Date)]

    }
}
