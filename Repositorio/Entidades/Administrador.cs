namespace Repositorio.Entidades
{
    public class Administrador : EntidadeBase
    {
        public int Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public bool Genero { get; set; }
        public IList<Administrador> Administradores { get; set; }
    }
}