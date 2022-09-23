using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Areas.Fornecedores.Controllers
{
    [Area("Fornecedores")]
    [Route("/fornecedor/")]
    [UsuarioLogado]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}