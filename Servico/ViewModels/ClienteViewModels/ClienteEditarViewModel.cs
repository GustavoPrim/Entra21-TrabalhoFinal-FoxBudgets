using Repositorio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Servico.ViewModels.ClienteViewModels
{
    public class ClienteEditarViewModel 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Crea { get; set; }
        public IList<Cliente> Clientes { get; set; }
    }
}