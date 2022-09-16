using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Materiais;

namespace Aplicacao.Administradores.Controllers
{
    [Route("material")]
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
            return Ok(materiais);
        }
        private List<string> ObterMateriais()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpGet("cadastrarmateriais")]
        public IActionResult CadastrarMateriais()
        {
            ViewBag.Materiais = ObterMateriais();

            var materialCadastrarViewModel = new MateriaisCadastrarViewModel();

            return View(materialCadastrarViewModel);
        }

        [HttpPost("cadastrarmateriais")]
        public IActionResult CadastrarMateriais([FromForm] MateriaisCadastrarViewModel cadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = ObterMateriais();
                return View(cadastrarViewModel);
            }

            _materialService.CadastrarMateriais(cadastrarViewModel);
            return RedirectToAction("ListarMateriais");
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromBody] int id)
        {
            var material = _materialService.ObterPorId(id);

            if(material == null)
                return NotFound();

            return Ok(material);
        }

        [HttpGet("editarmateriais")]
        public IActionResult EditarMateriais([FromQuery] int id)
        {
            var material = _materialService.ObterPorId(id);
            var materiais = ObterMateriais();

            var fornecedorEditarViewModel = new MateriaisEditarViewModel
            {
                Id = material.Id,
                Nome = material.Nome,
                Sku = material.Sku,
                DataValidade = material.DataValidade,
                Descricao = material.Descricao,
            };
            ViewBag.Materiais = materiais;

            return View(fornecedorEditarViewModel);
        }

        [HttpPost("editarmateriais")]
        public IActionResult EditarMateriais([FromForm] MateriaisEditarViewModel editarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = ObterMateriais();
                return View(editarViewModel);
            }
            _materialService.EditarMateriais(editarViewModel);
            return RedirectToAction("ListarFornecedor");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromBody] int id)
        {
            var apagou = _materialService.Apagar(id);

            if (!apagou)
                return NotFound();

            return Ok();
        }

    }
}