using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Fornecedor.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
