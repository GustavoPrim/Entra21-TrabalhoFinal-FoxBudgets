namespace Repositorio.Entidades
{
    public class Material : EntidadeBase
    {
        public string Sku { get; set; }
        public DateTime DataValidade { get; set; }
        public string Descricao { get; set; }
    }
}