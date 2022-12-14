using Aplicacao.Filtros;
using Aplicacao.Help;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entidades;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Orcamentos;

namespace Aplicacao.Areas.Clientes.Controllers
{
    [Area("Clientes")]
    [Route("cliente/cotacao")]
    [UsuarioLogado]
    public class CotacaoController : Controller
    {
        private readonly IOrcamentoServico _orcamentoServico;
        private readonly IMaterialService _materiaServico;
        private readonly ISessao _sessao;

        public CotacaoController(IOrcamentoServico orcamentoServico, IMaterialService materiaServico, ISessao sessao)
        {
            _orcamentoServico = orcamentoServico;
            _materiaServico = materiaServico;
            _sessao = sessao;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var orcamento = _orcamentoServico.ObterTodos();
            return View("index", orcamento);
        }

        [HttpGet("cotar")]
        public IActionResult Cotar()
        {
            ViewBag.Orcamentos = ObterOrcamentos();
            ViewBag.Materiais = _materiaServico.ObterTodos();
            var orcamentoCadastrarViewMOdel = new OrcamentoCadastrarViewModel();
            return View(orcamentoCadastrarViewMOdel);
        }

        [HttpPost("adicionarProduto")]
        public IActionResult AdicionarProduto(OrcamentoCadastrarViewModel orcamentoCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Materiais = _materiaServico.ObterTodos();
                ViewBag.Administradores = ObterOrcamentos();
                return View(orcamentoCadastrarViewModel);
            }

            var clienteId = _sessao.BuscarSessaoUsuario<Cliente>().Id;

            _orcamentoServico.Cotar(orcamentoCadastrarViewModel, clienteId);

            return Ok();
        }

        [HttpGet("calcular")]
        public IActionResult Calcular()
        {
            var idCliente = _sessao.BuscarSessaoUsuario<Cliente>().Id;

            var materiais = _orcamentoServico.Calcular(idCliente);

            return View(materiais);
        }

        [HttpGet("obtertodos")]
        public IActionResult ObterTodos()
        {
            var selectViewModel = _orcamentoServico.ObterTodos();
            return Ok(selectViewModel);
        }

        [HttpGet("obterItensOrcamentoAtual")]
        public IActionResult ObterItensOrcamentoAtual()
        {
            var idUsuarioLogado = _sessao.BuscarSessaoUsuario<Cliente>().Id;

            var itens = _orcamentoServico.ObterItensOrcamentoAtual(idUsuarioLogado);

            return Ok(itens);
        }

        private List<string> ObterOrcamentos()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}