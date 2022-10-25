using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels;

public class CadastrarUsuarioViewModel
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [RegularExpression(@"^[a-zãóáçA-Z''-'\s]{1,100}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
    public string Nome { get; set; }

    [Display(Name = "Cpf")]
    [StringLength(14, ErrorMessage = "{0} deve conter {1} caracteres")]
    public string? Cpf { get; set; }

    [Display(Name = "Cnpj")]
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
    public string Telefone { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} dígitos")]
    public string Senha { get; set; } = "";

    public Guid Token { get; set; }

    public DateTime DataInspiracaoToken { get; set; }

    [Display(Name = "Login")]
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(1, ErrorMessage = "{0} deve conter no mínimo {1} dígitos")]
    public string Login { get; set; }

    public IFormFile? Arquivo { get; set; }
}