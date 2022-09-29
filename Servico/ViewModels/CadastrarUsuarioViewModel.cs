using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [RegularExpression(@"^[a-zãçA-Z''-'\s]{1,100}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Display(Name = "Cpf")]
        //[Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(14, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string? Cpf { get; set; }

        [Display(Name = "Cnpj")]
        //[Required(ErrorMessage = "{0} deve ser preenchido")]
        //[RegularExpression(@"\d{2,3}.\d{3}.\d{3}/\d{4}-\d{2}", ErrorMessage = "Digite um CNPJ válido!")]
        [MaxLength(18, ErrorMessage = "Digite um CNPJ válido!")]
        public string? Cnpj { get; set; }

        [Display(Name = "DataNascimento")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Endereco")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1} caracter")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "{0} deve ser preenchido")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{3}$", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression("^[(]{1}[0-9]{2}[)]{1}[ ][0-9]{5}[-]{1}[0-9]{4}$", ErrorMessage = "Digite um número de telefone válido")]
        public string Telefone { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} dígitos")]
        public string Senha { get; set; } = "";

        //[DataType(DataType.Password)]
        //[Display(Name = "ConfirmarSenha")]
        //[Required(ErrorMessage = "{0} deve ser preenchido")]
        //[MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} dígitos")]
        //public string ConfirmarSenha { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1} dígitos")]
        public string Login { get; set; }
    }
}
