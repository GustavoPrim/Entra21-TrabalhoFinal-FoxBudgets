using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administrador.Controllers
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
