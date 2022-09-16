namespace Repositorio.Entidades
{
    public class Estoque : EntidadeBase
    {
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public IList<Estoque> Estoques { get; set; }
    }
}
