using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administradores.Controllers
{
    public class AdministradorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
