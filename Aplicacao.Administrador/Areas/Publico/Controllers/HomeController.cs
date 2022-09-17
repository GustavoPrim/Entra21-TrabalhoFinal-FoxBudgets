using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administrador.Areas.Publico.Controllers
{
    [Area("Publico")]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
