using System.ComponentModel.DataAnnotations;

namespace Repositorio.Entidades
{
    public class Adm : EntidadeBase
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Digite o login")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string? Senha { get; set; }
        public IList<Adm> Administradores { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}