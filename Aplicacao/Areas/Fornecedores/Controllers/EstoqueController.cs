using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Estoque;

namespace Aplicacao.Areas.Fornecedores.Controllers
{
    [Route("estoque")]
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

        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var selectViewModel = _estoqueServico.ObterTodos();
            return Ok(selectViewModel);
        }

        private List<string> ObterEstoques()
        {
            return Enum.GetNames<EstoqueEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
