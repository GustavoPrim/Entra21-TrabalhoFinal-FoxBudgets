using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Areas.Administradores.Controllers
{
    [Area("Administradores")]
    [Route("/administrador/")]
    [UsuarioLogado]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}