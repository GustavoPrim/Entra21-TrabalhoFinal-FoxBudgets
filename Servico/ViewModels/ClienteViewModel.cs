using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels
{
    public class ClienteViewModel
    {
        //[Display(Name = "Nome")]
        [Display(Name = nameof(Cpf))]
        [Required(ErrorMessage = "Selecione um item")]
        public string Cpf { get; set; }

        [Display(Name = nameof(Cnpj))]
        [Required(ErrorMessage = "Selecione um item")]
        public string Cnpj { get; set; }

        [Display(Name = nameof(DataNascimento))]
        public DateTime DataNascimento { get; set; }

        [Display(Name = nameof(Endereco))]
        public string Endereco { get; set; }

        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        [Display(Name = nameof(Telefone))]
        public int Telefone { get; set; }

        [Display(Name = nameof(Crea))]
        public string Crea { get; set; }
    }
}