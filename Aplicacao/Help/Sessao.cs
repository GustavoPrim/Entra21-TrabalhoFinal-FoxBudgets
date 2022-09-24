using Newtonsoft.Json;
using Repositorio.Entidades;

namespace Aplicacao.Help
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Administrador BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return null;

            return JsonConvert.DeserializeObject<Administrador>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(EntidadeBase entidadeBase)
        {
            string valor = JsonConvert.SerializeObject(entidadeBase);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
