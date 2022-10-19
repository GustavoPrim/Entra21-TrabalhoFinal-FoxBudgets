using Aplicacao.Help;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entidades;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Estoque;
using Servico.ViewModels.Orcamentos;

namespace Aplicacao.Areas.Fornecedores.Controllers
{
    [Area("Fornecedores")]
    [Route("fornecedor/estoque")]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueServico _estoqueServico;
        private readonly ISessao _sessao;
        private readonly IOrcamentoServico _orcamentoServico;
        private readonly IMaterialService _materialService;

        public EstoqueController(IEstoqueServico estoqueServico, ISessao sessao, IOrcamentoServico orcamentoServico, IMaterialService materialService)
        {
            _estoqueServico = estoqueServico;
            _sessao = sessao;
            _orcamentoServico = orcamentoServico;
            _materialService = materialService;
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

        [HttpGet("saida")]
        public IActionResult ObterSaida()
        {
            var saida = _estoqueServico.ObterTodos();
            return View("Saida", saida);
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

        [HttpPost("adicionarProduto")]
        public IActionResult AdicionarProduto(OrcamentoCadastrarViewModel orcamentoCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = _materialService.ObterTodos();
                ViewBag.Administradores = ObterOrcamentos();
                return View(orcamentoCadastrarViewModel);
            }

            var clienteId = _sessao.BuscarSessaoUsuario<Cliente>().Id;

            _orcamentoServico.Cotar(orcamentoCadastrarViewModel, clienteId);

            return Ok();
        }

        private List<string> ObterOrcamentos()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpGet("obterItensOrcamentoAtual")]
        public IActionResult ObterItensOrcamentoAtual()
        {
            var idUsuarioLogado = _sessao.BuscarSessaoUsuario<Cliente>().Id;

            var itens = _orcamentoServico.ObterItensOrcamentoAtual(idUsuarioLogado);

            return Ok(itens);
        }
    }
}
