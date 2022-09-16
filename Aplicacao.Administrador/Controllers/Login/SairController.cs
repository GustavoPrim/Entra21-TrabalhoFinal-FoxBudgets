using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administrador.Controllers.Login
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
