using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    [Route("administrador/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
