using Repositorio.Entidades;

namespace Aplicacao.Administrador.Help
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Adm usuarioModel);
        void RemoverSessaoUsuario();
        Adm BuscarSessaoUsuario();
    }
}
