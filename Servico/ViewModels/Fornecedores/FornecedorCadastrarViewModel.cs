using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Fornecedores
{
    public class FornecedorCadastrarViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"^[a-zãçA-Z''-'\s]{1,100}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"\d{2,3}.\d{3}.\d{3}/\d{4}-\d{2}", ErrorMessage = "Digite um CNPJ válido!")]
        [MaxLength(18, ErrorMessage = "Digite um CNPJ válido!")]
        public string Cnpj { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [MinLength(8, ErrorMessage = "{0} deve conter pelo menos {1} caracteres!" )]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string Endereco { get; set; }

        [Display(Name = "Data de fundação")]
        [Required(ErrorMessage = "{0} deve ser preenchida!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFundacao { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "{0} deve ser especificada!")]
        public int Categoria { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{3}$", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        [RegularExpression("^[(]{1}[0-9]{2}[)]{1}[ ][0-9]{5}[-]{1}[0-9]{4}$", ErrorMessage = "Digite um número de telefone válido")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "{0} deve ser preenchido!")]
        public string Senha { get; set; }

    }
}