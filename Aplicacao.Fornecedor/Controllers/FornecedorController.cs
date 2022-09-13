using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Fornecedores;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Aplicacao.Administradores.Controllers
{
    [Route("fornecedor")]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorServico _fornecedorServico;

        public FornecedorController(IFornecedorServico fornecedorServico)
        {
            _fornecedorServico = fornecedorServico;
        }

        [HttpGet]
        public IActionResult ListarFornecedor()
        {
            var fornecedor = _fornecedorServico.ObterTodos();
            return View("listarfornecedor", fornecedor);
        }

        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var fornecedores = _fornecedorServico.ObterTodos().ToList();
            return Ok(fornecedores);
        }

        [HttpGet("cadastrarfornecedor")]
        public IActionResult CadastrarFornecedor()
        {
            ViewBag.Fornecedores = ObterFornecedores();

            var fornecedorCadastrarViewModel = new FornecedorCadastrarViewModel();
            return View(fornecedorCadastrarViewModel);
        }

        [HttpPost("cadastrarfornecedor")]
        public IActionResult CadastrarFornecedor([FromForm] FornecedorCadastrarViewModel fornecedorCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
               ViewBag.Fornecedores = ObterFornecedores();
                return View(fornecedorCadastrarViewModel);
            }

            _fornecedorServico.CadastrarFornecedor(fornecedorCadastrarViewModel);
            return RedirectToAction("ListarFornecedor");
        }

        [HttpGet("obterPorId")]
        public IActionResult ObterPorId([FromQuery] int id)
        {
            var fornecedor = _fornecedorServico.ObterPorId(id);

            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromBody] FornecedorEditarViewModel viewModel)
        {
            var alterar = _fornecedorServico.Editar(viewModel);

            if (!alterar)
                return NotFound();

            return Ok();
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            var apagar = _fornecedorServico.Apagar(id);

            if (!apagar)
                return NotFound();

            return Ok();
        }

        private List<string> ObterFornecedores()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}