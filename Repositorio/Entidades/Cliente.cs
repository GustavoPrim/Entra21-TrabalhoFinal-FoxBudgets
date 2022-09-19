namespace Repositorio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        //public string Login { get; set; }
        //public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        //public bool SenhaValida(string senha)
        //{
        //    return Senha == senha;
        //}
    }
}