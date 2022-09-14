using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;
using Servico.ViewModels.Materiais;

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
            return Ok(materiais);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] MateriaisCadastrarViewModel cadastrarViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var material = _materialService.Cadastrar(cadastrarViewModel);
            return Ok(material);
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromBody] int id)
        {
            var material = _materialService.ObterPorId(id);

            if(material == null)
                return NotFound();

            return Ok(material);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromBody] MateriaisEditarViewModel editarViewModel)
        {
            var alterou = _materialService.Editar(editarViewModel);

            if(!alterou)
                return NotFound();

            return Ok();
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