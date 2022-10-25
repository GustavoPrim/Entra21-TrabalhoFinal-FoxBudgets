using Microsoft.AspNetCore.Mvc.Filters;

namespace Aplicacao.Filtros
{
    public class UsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}