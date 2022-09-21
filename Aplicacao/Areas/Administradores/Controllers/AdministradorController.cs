using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Administradores;

namespace Aplicacao.Areas.Administradores.Controllers
{
    [Area("Administradores")]
    [Route("administrador/administrador")]
    [UsuarioLogado]
    public class AdministradorController : Controller
    {
        private readonly IAdministradorServico _administradorServico;

        public AdministradorController(IAdministradorServico administradorServico)
        {
            _administradorServico = administradorServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var administrador = _administradorServico.ObterTodos();
            return View("index", administrador);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Administradores = ObterAdministradores();

            var administradorCadastrarViewModel = new AdministradorCadastrarViewModel();

            return View(administradorCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] AdministradorCadastrarViewModel administradorCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Administradores = ObterAdministradores();
                return View(administradorCadastrarViewModel);
            }

            _administradorServico.Cadastrar(administradorCadastrarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _administradorServico.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var administrador = _administradorServico.ObterPorId(id);
            var administradores = ObterAdministradores();

            var administradorEditarViewModel = new AdministradorEditarViewModel
            {
                Id = administrador.Id,
                Nome = administrador.Nome,
                DataNascimento = administrador.DataNascimento,
                Email = administrador.Email,
                Endereco = administrador.Endereco,
                Telefone = administrador.Telefone,
                Cpf = administrador.Cpf
            };
            ViewBag.Administradores = administradores;

            return View(administradorEditarViewModel);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromForm] AdministradorEditarViewModel administradorEditarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Administradores = ObterAdministradores();
                return View(administradorEditarViewModel);
            }
            _administradorServico.Editar(administradorEditarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("obterTodos")]
        public IActionResult ObterTodos()
        {
            var selectViewModel = _administradorServico.ObterTodos();
            return Ok(selectViewModel);
        }
        private List<string> ObterAdministradores()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }

        private List<string> ObterFornecedores()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}