namespace Repositorio.Entidades
{
    public class Cliente : Usuario
    {
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public IList<Orcamento> Orcamentos { get; set; }

    }
}