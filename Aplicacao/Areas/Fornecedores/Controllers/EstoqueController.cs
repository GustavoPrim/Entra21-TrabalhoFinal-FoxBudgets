using Aplicacao.Filtros;
using Aplicacao.Help;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entidades;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Estoque;

namespace Aplicacao.Areas.Fornecedores.Controllers
{
    [Area("Fornecedores")]
    [Route("fornecedor/estoque")]
    [UsuarioLogado]
    public class EstoqueController : Controller
    {
        private readonly IEstoqueServico _estoqueServico;
        private readonly ISessao _sessao;
        private readonly IMaterialService _materialService;

        public EstoqueController(IEstoqueServico estoqueServico, ISessao sessao, IOrcamentoServico orcamentoServico, IMaterialService materialService)
        {
            _estoqueServico = estoqueServico;
            _sessao = sessao;
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

        //[HttpPost("cadastrar")]
        //public IActionResult Cadastrar([FromForm] EstoqueCadastrarViewModel estoqueCadastrarViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Administradores = ObterEstoques();
        //        return View(estoqueCadastrarViewModel);
        //    }

        //    _estoqueServico.CadastrarValor(estoqueCadastrarViewModel);

        //    return RedirectToAction("Index");
        //}

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

        private List<string> ObterEstoques()
        {
            return Enum.GetNames<EstoqueEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpPost("adicionarProduto")]
        public IActionResult AdicionarProduto(EstoqueCadastrarViewModel estoqueCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = _estoqueServico.ObterTodos();
                ViewBag.Valor = _estoqueServico.ObterTodos();
                ViewBag.Quantidade = _estoqueServico.ObterTodos();
                return View(estoqueCadastrarViewModel);
            }

            var fornecedorId = _sessao.BuscarSessaoUsuario<Fornecedor>().Id;

            _estoqueServico.Estocar(estoqueCadastrarViewModel, fornecedorId);

            return Ok();
        }

        private List<string> ObterOrcamentos()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpGet("obterItensEstoqueAtual")]
        public IActionResult ObterItensEstoqueAtual()
        {
            var idUsuarioLogado = _sessao.BuscarSessaoUsuario<Fornecedor>().Id;

            var itens = _estoqueServico.ObterItensEstoqueAtual(idUsuarioLogado);

            return Ok(itens);
        }
    }
}