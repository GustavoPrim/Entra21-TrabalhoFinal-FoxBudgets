using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Administradores
{
    public class AdministradorCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"^[a-zãóáçA-Z''-'\s]{3,100}$", ErrorMessage ="Números e caracteres especiais não são permitidos no nome!")]
        public string Nome { get; set; }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MaxLength(14, ErrorMessage = "Digite um CPF válido!")]
        public string Cpf { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1} caracteres!")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string Endereco { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{3}$", ErrorMessage = "Informe um e-mail válido!")]
        [MaxLength(100, ErrorMessage = "Informe um e-mail válido!")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MaxLength(15, ErrorMessage = "Informe um número de telefone válido!")]
        public string Telefone { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1} dígitos!")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} dígitos!")]
        public string Senha { get; set; }
    }
}