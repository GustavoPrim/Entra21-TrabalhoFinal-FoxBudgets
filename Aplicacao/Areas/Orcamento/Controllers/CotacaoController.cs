using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Orcamentos;

namespace Aplicacao.Areas.Orcamento.Controllers
{
    [Area("Orcamento")]
    [Route("Cotar")]
    [UsuarioLogado]
    public class CotacaoController : Controller
    {
        private readonly IOrcamentoServico _orcamentoServico;
        public CotacaoController(IOrcamentoServico orcamentoServico)
        {
            _orcamentoServico = orcamentoServico;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var orcamento = _orcamentoServico.ObterTodos();
            return View("index", orcamento);
        }
        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Orcamentos = ObterOrcamentos();
            var orcamentoCadastrarViewMOdel = new OrcamentoCadastrarViewModel();
            return View(orcamentoCadastrarViewMOdel);
        }
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] OrcamentoCadastrarViewModel orcamentoCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Administradores = ObterOrcamentos();
                return View(orcamentoCadastrarViewModel);
            }

            _orcamentoServico.Solicitar(orcamentoCadastrarViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _orcamentoServico.Apagar(id);
            return RedirectToAction("Index");
        }
        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var orcamento = _orcamentoServico.ObterPorId(id);
            var orcamentos = ObterOrcamentos();
            var orcamentoEditarViewModel = new OrcamentoEditarViewModel
            {
                Id = orcamento.Id,
                DataOrcamento = orcamento.DataOrcamento,
                Quantidade = orcamento.Quantidade,
                //Item = orcamento.Item
            };
            ViewBag.Orcamentos = orcamentos;
            return View(orcamentoEditarViewModel);
        }
        [HttpPost("editar")]
        public IActionResult Editar([FromForm] OrcamentoEditarViewModel orcamentoEditarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Orcamentos = ObterOrcamentos();
                return View(orcamentoEditarViewModel);
            }
            _orcamentoServico.Editar(orcamentoEditarViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet("obtertodos")]
        public IActionResult ObterTodos()
        {
            var selectViewModel = _orcamentoServico.ObterTodos();
            return Ok(selectViewModel);
        }
        private List<string> ObterOrcamentos()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
