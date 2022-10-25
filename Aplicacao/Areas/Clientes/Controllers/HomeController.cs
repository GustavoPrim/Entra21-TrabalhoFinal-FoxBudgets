using Aplicacao.Help;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entidades;

namespace Aplicacao.Areas.Clientes.Controllers
{
    [Area("Clientes")]
    [Route("/cliente/")]
    public class HomeController : Controller
    {
        private readonly ISessao _sessao;

        public HomeController(ISessao sessao)
        {
            _sessao = sessao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cliente = _sessao.BuscarSessaoUsuario<Cliente>();

            ViewBag.ClienteNome = cliente.Nome;

            return View();
        }
    }
}