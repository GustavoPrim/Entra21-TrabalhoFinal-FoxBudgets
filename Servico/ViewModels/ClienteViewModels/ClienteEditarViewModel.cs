using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.ClienteViewModels
{
    public class ClienteEditarViewModel : ClienteViewModel
    {
        int Id { get; set; }
        [Required]
        string Nome { get; set; }
        [Required]
        string Email { get; set; }
        DateTime DataNascimento { get; set; }
        [Required]
        string Endereco { get; set; }
        string Telefone { get; set; }
    }
}