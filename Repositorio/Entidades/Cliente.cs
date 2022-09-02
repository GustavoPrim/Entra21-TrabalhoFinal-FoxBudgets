namespace Repositorio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Endereco { get; set; }
        public string EnderecoConstrutora { get; set; }
        public string Email { get; set; }
        public string EmailConstrutora { get; set; }
        public int Telefone { get; set; }
        public int TelefoneComercial { get; set; }
        public string Crea { get; set; }
    }
}