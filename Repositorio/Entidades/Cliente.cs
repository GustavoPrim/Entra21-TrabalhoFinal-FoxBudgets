namespace Repositorio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Crea { get; set; }
    }
}