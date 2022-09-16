using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Administradores;
using Servico.ViewModels.Fornecedores;

namespace Aplicacao.Administrador.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IAdministradorServico _administradorServico;
        private readonly IFornecedorServico _fornecedorServico;

        public AdministradorController(IAdministradorServico administradorServico)
        {
            _administradorServico = administradorServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        private List<string> ObterFornecedores()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        [HttpGet("cadastrarfornecedor")]
        public IActionResult CadastrarFornecedor()
        {
            ViewBag.Fornecedores = ObterFornecedores();

            var fornecedorCadastrarViewModel = new FornecedorCadastrarViewModel();

            return View(fornecedorCadastrarViewModel);
        }

        /*[HttpPost("cadastrarfornecedor")]
        public IActionResult CadastrarFornecedor([FromForm] FornecedorCadastrarViewModel fornecedorCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Fornecedores = ObterFornecedores();
                return View(fornecedorCadastrarViewModel);
            }

            _fornecedorServico.Cadastrar(fornecedorCadastrarViewModel);
            return RedirectToAction("ListarFornecedor");
        }*/
    }
}