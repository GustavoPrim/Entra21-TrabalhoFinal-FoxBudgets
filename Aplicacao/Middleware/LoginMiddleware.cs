using Aplicacao.Help;
using Repositorio.Entidades;

namespace Aplicacao.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        // IMyScopedService is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext, ISessao sessao)
        {
            var area = httpContext.GetRouteData().Values["area"]?.ToString() ?? string.Empty ;

            var cliente = sessao.BuscarSessaoUsuario<Cliente>();
            var fornecedor = sessao.BuscarSessaoUsuario<Fornecedor>();
            var administrador = sessao.BuscarSessaoUsuario<Administrador>();

            if(IsNotAuthenticatedAndRightAccessToArea(cliente, area, "Clientes") ||
                IsNotAuthenticatedAndRightAccessToArea(fornecedor, area, "Fornecedores") ||
                IsNotAuthenticatedAndRightAccessToArea(administrador, area, "Administradores"))
            {
                httpContext.Response.Redirect("/login");
                return;
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
