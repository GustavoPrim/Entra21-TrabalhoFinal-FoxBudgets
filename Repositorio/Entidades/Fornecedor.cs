namespace Repositorio.Entidades
{
    public class Fornecedor : Usuario
    {
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int Categoria { get; set; }
        public IList<Estoque> Estoques { get; set; }
    }
}