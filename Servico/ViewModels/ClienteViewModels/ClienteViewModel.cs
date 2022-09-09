using Repositorio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.ClienteViewModels
{
    public class ClienteViewModel : EntidadeBase
    {
        [Display(Name = nameof(Nome))]
        [Required(ErrorMessage = "Digite algo.")]
        public string Nome { get; set; }

        [Display(Name = nameof(Cpf))]
        [Required(ErrorMessage = "Selecione um CPF válido.")]

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
        public int Telefone { get; set; }

        [Display(Name = nameof(Crea))]
        public string Crea { get; set; }
    }
}