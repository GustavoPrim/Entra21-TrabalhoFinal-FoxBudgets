using Aplicacao.Help;
using Repositorio.Entidades;

namespace Aplicacao.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ISessao sessao)
        {
            var area = httpContext.GetRouteData().Values["area"]?.ToString() ?? string.Empty;
            var action = httpContext.GetRouteData().Values["action"]?.ToString() ?? string.Empty;
            var controller = httpContext.GetRouteData().Values["controller"]?.ToString() ?? string.Empty;

            var cliente = sessao.BuscarSessaoUsuario<Cliente>();
            var fornecedor = sessao.BuscarSessaoUsuario<Fornecedor>();
            var administrador = sessao.BuscarSessaoUsuario<Administrador>();

            if (IsNotAuthenticatedAndRightAccessToArea(cliente, area, "Clientes") ||
                IsNotAuthenticatedAndRightAccessToArea(fornecedor, area, "Fornecedores") ||
                IsNotAuthenticatedAndRightAccessToArea(administrador, area, "Administradores"))
            {
                httpContext.Response.Redirect("/login");
                return;
            }

            if (area == "Publico" && controller == "Login" && action == "Sair")
            {
                await _next(httpContext);
            }

            if (IsAuthenticatedAndRightAccessToArea(cliente, area))
            {
                httpContext.Response.Redirect("/cliente");
                return;
            }

            if (IsAuthenticatedAndRightAccessToArea(fornecedor, area))
            {
                httpContext.Response.Redirect("/fornecedor");
                return;
            }

            if (IsAuthenticatedAndRightAccessToArea(administrador, area))
            {
                httpContext.Response.Redirect("/administrador");
                return;
            }

            var usuarioLogadoCliente = sessao.BuscarSessaoUsuario<Cliente>();
            var usuarioLogadoFornecedor = sessao.BuscarSessaoUsuario<Fornecedor>();
            var usuarioLogadoAdministrador = sessao.BuscarSessaoUsuario<Administrador>();

            if (usuarioLogadoCliente != null)
            {
                httpContext.Items.Add("UsuarioNome", usuarioLogadoCliente.Nome);
            }
            if (usuarioLogadoFornecedor != null)
            {
                httpContext.Items.Add("UsuarioNome", usuarioLogadoFornecedor.Nome);
            }
            if (usuarioLogadoAdministrador != null)
            {
                httpContext.Items.Add("UsuarioNome", usuarioLogadoAdministrador.Nome);
            }

            await _next(httpContext);
        }

        private bool IsNotAuthenticatedAndRightAccessToArea(Usuario usuario, string area, string areaDesejada)
        {
            return usuario == null && area == areaDesejada;
        }

        private bool IsAuthenticatedAndRightAccessToArea(Usuario usuario, string area)
        {
            return usuario != null && area == "Publico";
        }
    }
}