using Repositorio.Entidades;

namespace Aplicacao.Help
{
    public interface ISessao
    {
        void CriarSessaoUsuario<TEntidade>(TEntidade entidadeBase) where TEntidade : Usuario;
        void RemoverSessaoUsuario<TEntidade>() where TEntidade : Usuario;
        TEntidade BuscarSessaoUsuario<TEntidade>() where TEntidade : Usuario;
    }
}