using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administradores.Controllers.Login
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
