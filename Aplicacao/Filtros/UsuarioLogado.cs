using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Repositorio.Entidades;

namespace Aplicacao.Filtros
{
    public class UsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            //if (string.IsNullOrEmpty(sessaoUsuario))
            //{
            //    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            //}
            //else
            //{
            //    var usuario = JsonConvert.DeserializeObject<Administrador>(sessaoUsuario);
            //    var usuarioFornecedor = JsonConvert.DeserializeObject<Fornecedor>(sessaoUsuario);
            //    var usuarioCliente = JsonConvert.DeserializeObject<Cliente>(sessaoUsuario);

            //    if (usuario == null ||usuarioFornecedor == null || usuarioCliente == null)
            //    {
            //        context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "area", "Publico" }, { "action", "index" } });
            //    }
            //}

            base.OnActionExecuting(context);
        }
    }
}