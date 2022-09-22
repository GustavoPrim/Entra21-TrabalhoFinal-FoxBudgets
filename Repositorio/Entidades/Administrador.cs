using System.ComponentModel.DataAnnotations;

namespace Repositorio.Entidades
{
    public class Administrador : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
   
    }
}