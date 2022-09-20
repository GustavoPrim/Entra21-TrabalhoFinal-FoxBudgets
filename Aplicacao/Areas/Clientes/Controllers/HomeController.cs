using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Areas.Clientes.Controllers
{
    [Area("Cliente")]
    [Route("/cliente/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
