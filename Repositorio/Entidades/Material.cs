namespace Repositorio.Entidades
{
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sku { get; set; }
        public DateTime DataValidade { get; set; }
        public string Descricao { get; set; }
    }
}