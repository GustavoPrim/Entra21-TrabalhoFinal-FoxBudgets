using Newtonsoft.Json;
using Repositorio.Entidades;

namespace Aplicacao.Help
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private const string SessionKeyAdministrator = "administratorSession";
        private const string SessionKeyClient = "clientSession";
        private const string SessionKeySupplier = "supplierSession";

        public void CriarSessaoUsuario<TEntidade>(TEntidade userBase) where TEntidade : Usuario
        {
            var userBaseString = JsonConvert.SerializeObject(userBase);

            var sessionKey = GetSessionKey<TEntidade>();

            GetSession().SetString(sessionKey, userBaseString);
        }

        public TEntidade? BuscarSessaoUsuario<TEntidade>() where TEntidade : Usuario
        {
            var sessionKey = GetSessionKey<TEntidade>();

            var session = GetSession().GetString(sessionKey);

            if (string.IsNullOrEmpty(session))
                return default;

            return JsonConvert.DeserializeObject<TEntidade>(session);
        }

        public void RemoverSessaoUsuario<TEntidade>() where TEntidade : Usuario
        {
            var sessionKey = GetSessionKey<TEntidade>();

            GetSession().Remove(sessionKey);
        }

        private string GetSessionKey<TEntidade>() where TEntidade : Usuario
        {
            var type = typeof(TEntidade);

            if (type == typeof(Administrador))
                return SessionKeyAdministrator;

            if (type == typeof(Cliente))
                return SessionKeyClient;

            return SessionKeySupplier;
        }

        private ISession GetSession() =>
            _httpContextAccessor.HttpContext.Session;
    }
}