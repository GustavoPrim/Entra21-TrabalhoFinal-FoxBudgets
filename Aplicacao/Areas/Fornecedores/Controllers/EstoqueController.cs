using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Estoque;

namespace Aplicacao.Areas.Fornecedores.Controllers
{
    [Area("Fornecedor")]
    [Route("fornecedor/estoque")]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueServico _estoqueServico;

        public EstoqueController(IEstoqueServico estoqueServico)
        {
            _estoqueServico = estoqueServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var estoque = _estoqueServico.ObterTodos();
            return View("index", estoque);
        }
        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Estoques = ObterEstoques();

            var estoqueCadastrarViewModel = new EstoqueCadastrarViewModel();

            return View(estoqueCadastrarViewModel);
        }
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] EstoqueCadastrarViewModel estoqueCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Administradores = ObterEstoques();
                return View(estoqueCadastrarViewModel);
            }
            _estoqueServico.CadastrarValor(estoqueCadastrarViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _estoqueServico.Apagar(id);
            return RedirectToAction("Index");
        }
        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var selectViewModel = _estoqueServico.ObterTodos();
            return Ok(selectViewModel);
        }
        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var estoque = _estoqueServico.ObterPorId(id);
            var estoques = ObterEstoques();

            var estoqueEditarViewModel = new EstoqueEditarViewModel
            {
                Quantidade = estoque.Quantidade
            };
            ViewBag.Estoques = estoques;

            return View(estoqueEditarViewModel);
        }
        [HttpPost("editar")]
        public IActionResult Editar([FromForm] EstoqueEditarViewModel estoqueEditarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estoques = ObterEstoques();
                return View(estoqueEditarViewModel);
            }
            _estoqueServico.Editar(estoqueEditarViewModel);
            return RedirectToAction("Index");
        }
        private List<string> ObterEstoques()
        {
            return Enum.GetNames<EstoqueEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}