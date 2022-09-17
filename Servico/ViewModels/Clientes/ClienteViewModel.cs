using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.Clientes
{
    public class ClienteViewModel
    {
        [Display(Name = nameof(Nome))]
        [Required(ErrorMessage = "Selecione um item")]
        public string Nome { get; set; }

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
        public string Telefone { get; set; }
    }
}