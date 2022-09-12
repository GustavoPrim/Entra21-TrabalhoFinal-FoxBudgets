using Aplicacao.Administrador.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Administrador.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            //if (Session["Erro"] != null)
                //ViewBag.Erro = Session["Erro"].ToString();

            return View();
        }

		[HttpPost]
        public void ChecarLogin()
		{
            var usuario = new Usuarios();
			//usuario.Email = Request["Email"];
            //usuario.Senha = Request["PassWord"];

            if (usuario.Login())
            {
                //Session["Autorizado"] = "OK";
                //Session.Remove("Erro");
                Response.Redirect("/Home/Index");
            }
			else
			{
                Response.Redirect("/Login/Index");
                //Session["Erro"] = "Senha ou usuário invál";
			}
		}
    }
}
