using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Fornecedores;

namespace Aplicacao.Areas.Administradores.Controllers
{
    [Area("Administradores")]
    [Route("administrador/fornecedor")]
    [UsuarioLogado]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorServico _fornecedorServico;

        public FornecedorController(IFornecedorServico fornecedorServico)
        {
            _fornecedorServico = fornecedorServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var fornecedor = _fornecedorServico.ObterTodos();
            return View(fornecedor);
        }

        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var fornecedores = _fornecedorServico.ObterTodos();
            return Ok(fornecedores);
        }
        private List<string> ObterFornecedores()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Fornecedores = ObterFornecedores();

            var fornecedorCadastrarViewModel = new FornecedorCadastrarViewModel();

            return View(fornecedorCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] FornecedorCadastrarViewModel fornecedorCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Fornecedores = ObterFornecedores();
                return View(fornecedorCadastrarViewModel);
            }

            _fornecedorServico.CadastrarFornecedor(fornecedorCadastrarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromQuery] int id)
        {
            var fornecedor = _fornecedorServico.ObterPorId(id);

            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var fornecedor = _fornecedorServico.ObterPorId(id);
            var fornecedores = ObterFornecedores();

            var fornecedorEditarViewModel = new FornecedorEditarViewModel
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                DataFundacao = fornecedor.DataFundacao,
                Email = fornecedor.Email,
                Endereco = fornecedor.Endereco,
                Telefone = fornecedor.Telefone,
                Cnpj = fornecedor.Cnpj,
                Categoria = fornecedor.Categoria,
            };
            ViewBag.Fornecedores = fornecedores;

            return View(fornecedorEditarViewModel);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromForm] FornecedorEditarViewModel fornecedorEditarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Fornecedores = ObterFornecedores();
                return View(fornecedorEditarViewModel);
            }
            _fornecedorServico.Editar(fornecedorEditarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _fornecedorServico.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}