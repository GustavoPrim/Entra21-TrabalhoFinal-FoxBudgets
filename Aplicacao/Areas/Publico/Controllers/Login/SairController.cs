using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Areas.Publico.Controllers.Login
{
    public class SairController : Controller
    {
        public IActionResult Index()
        {
            //Session.Abandon();
            return View();
        }
    }
}
