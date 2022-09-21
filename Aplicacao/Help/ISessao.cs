using Repositorio.Entidades;

namespace Aplicacao.Help
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Repositorio.Entidades.EntidadeBase entidadeBase);
        void RemoverSessaoUsuario();
        Repositorio.Entidades.Administrador BuscarSessaoUsuario();
    }
}
