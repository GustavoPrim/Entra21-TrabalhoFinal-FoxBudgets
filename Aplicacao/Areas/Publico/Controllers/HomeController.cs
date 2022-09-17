using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Areas.Publico.Controllers
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
