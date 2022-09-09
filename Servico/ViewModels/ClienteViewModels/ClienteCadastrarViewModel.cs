using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Servico.ViewModels.ClienteViewModels
{
    public class ClienteCadastrarViewModel : ClienteViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1}")]
        [MaxLength(30, ErrorMessage = "{0} deve conter no máximo {1}")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "{0} deve conter {1} caracteres")]
        public string Cpf { get; set; }


        [Display(Name = nameof(Cnpj))]
        [Required(ErrorMessage = "Selecione um CNPJ válido.")]
        public string Cnpj { get; set; }


        [Display(Name = nameof(DataNascimento))]
        public DateTime DataNascimento { get; set; }

        [Display(Name = nameof(Endereco))]
        public string Endereco { get; set; }

        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        [Display(Name = nameof(Telefone))]
        public string Telefone { get; set; }

        [Display(Name = nameof(Crea))]
        public string Crea { get; set; }
    }
}