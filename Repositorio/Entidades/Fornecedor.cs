﻿namespace Repositorio.Entidades
{
    public class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int Categoria { get; set; }

        public IList<Estoque> Estoques { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}