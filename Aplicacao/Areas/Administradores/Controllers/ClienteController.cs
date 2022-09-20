using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Clientes;

namespace Aplicacao.Areas.Administradores.Controllers
{
    [Area("Administrador")]
    [Route("administrador/cliente")]
    [UsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cliente = _clienteService.ObterTodos();
            return View("index", cliente);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            ViewBag.Clientes = ObterClientes();

            var clienteCadastrarViewModel = new ClienteCadastrarViewModel();

            return View(clienteCadastrarViewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] ClienteCadastrarViewModel clienteCadastrarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Administradores = ObterClientes();
                return View(clienteCadastrarViewModel);
            }

            _clienteService.Cadastrar(clienteCadastrarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _clienteService.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpGet("editar")]
        public IActionResult Editar([FromQuery] int id)
        {
            var cliente = _clienteService.ObterPorId(id);
            var clientes = ObterClientes();

            var clienteEditarViewModel = new ClienteEditarViewModel
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Cnpj = cliente.Cnpj,
                DataNascimento = cliente.DataNascimento,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
            };
            ViewBag.Clientes = clientes;

            return View(clienteEditarViewModel);
        }

        [HttpPost("editar")]
        public IActionResult Editar([FromForm] ClienteEditarViewModel clienteEditarViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = ObterClientes();
                return View(clienteEditarViewModel);
            }
            _clienteService.Editar(clienteEditarViewModel);
            return RedirectToAction("Index");
        }

        [HttpGet("obterTodos")]
        public IActionResult Obtertodos()
        {
            var selectViewModel = _clienteService.ObterTodos();
            return Ok(selectViewModel);
        }
        private List<string> ObterClientes()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}