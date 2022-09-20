using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Materiais;

namespace Aplicacao.Areas.Administradores.Controllers
{
    [Area("Administrador")]
    [Route("administrador/material")]
    [UsuarioLogado]
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var material = _materialService.ObterTodos();
            return View(material);
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

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Materiais = ObterMateriais();

            var materialCadastrarViewModel = new MateriaisCadastrarViewModel();

            return View(materialCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] MateriaisCadastrarViewModel cadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = ObterMateriais();
                return View(cadastrarViewModel);
            }

            _materialService.Cadastrar(cadastrarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromBody] int id)
        {
            var material = _materialService.ObterPorId(id);

            if (material == null)
                return NotFound();

            return Ok(material);
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
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

        [HttpPost("editar")]
        public IActionResult Editar([FromForm] MateriaisEditarViewModel editarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = ObterMateriais();
                return View(editarViewModel);
            }
            _materialService.Editar(editarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var apagou = _materialService.Apagar(id);

            if (!apagou)
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}