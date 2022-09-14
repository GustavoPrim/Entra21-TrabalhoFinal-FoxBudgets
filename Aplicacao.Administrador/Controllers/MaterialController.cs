using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace Aplicacao.Administrador.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public IActionResult ListarMaterial()
        {
            var material = _materialService.ObterTodos();
            return View("listarmaterial", material);
        }

        [HttpGet("obtertodos")]
        public IActionResult ObterTodos()
        {
            var materiais = _materialService.ObterTodos().ToList();
            return Ok();
        }
    }
}
