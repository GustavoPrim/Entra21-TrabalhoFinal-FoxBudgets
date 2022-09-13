using Aplicacao.Administrador.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administrador.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
