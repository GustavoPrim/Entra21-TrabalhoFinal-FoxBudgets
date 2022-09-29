namespace Repositorio.Entidades
{
    public abstract class Usuario : EntidadeBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
