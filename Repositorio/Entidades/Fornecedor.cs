namespace Repositorio.Entidades
{
    public class Fornecedor : EntidadeBase
    {
        public string Cnpj { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Categoria { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}