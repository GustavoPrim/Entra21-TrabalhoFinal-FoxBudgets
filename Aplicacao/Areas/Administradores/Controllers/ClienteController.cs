using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels;
using Servico.ViewModels.Clientes;

namespace Aplicacao.Areas.Administradores.Controllers
{
    [Area("Administradores")]
    [Route("administrador/cliente")]
    [UsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ClienteController(
            IClienteService clienteService,
            IWebHostEnvironment webHostEnvironment)
        {
            _clienteService = clienteService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cliente = _clienteService.ObterTodos();
            return View(cliente);
        }

        //[HttpGet("cadastrar")]
        //public IActionResult Cadastrar()
        //{
        //    ViewBag.Clientes = ObterClientes();

        //    var clienteCadastrarViewModel = new ClienteCadastrarViewModel();

        //    return View(clienteCadastrarViewModel);
        //}

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var cliente = _clienteService.Cadastrar(cadastrarUsuarioViewModel, _webHostEnvironment.WebRootPath);
            return Ok(cliente);
        }

        [HttpGet("apagar")]
        public IActionResult Apagar([FromQuery] int id)
        {
            _clienteService.Apagar(id);
            return RedirectToAction("Index");
        }

        //[HttpGet("editar")]
        //public IActionResult Editar([FromQuery] int id)
        //{
        //    var cliente = _clienteService.ObterPorId(id);
        //    var clientes = ObterClientes();

        //    var clienteEditarViewModel = new ClienteEditarViewModel
        //    {
        //        Id = cliente.Id,
        //        Cpf = cliente.Cpf,
        //        Cnpj = cliente.Cnpj,
        //        DataNascimento = cliente.DataNascimento,
        //        Endereco = cliente.Endereco,
        //        Email = cliente.Email,
        //        Telefone = cliente.Telefone,
        //    };
        //    ViewBag.Clientes = clientes;

        //    return View(clienteEditarViewModel);
        //}

        [HttpPost("editar")]
        public IActionResult Editar([FromForm] ClienteEditarViewModel clienteEditarViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var cliente = _clienteService.Editar(clienteEditarViewModel, _webHostEnvironment.WebRootPath);

            return RedirectToAction("Index");
        }

        [HttpGet("obterTodos")]
        public IActionResult Obtertodos()
        {
            var clientes = _clienteService.ObterTodos();
            return Ok(clientes);
        }
        private List<string> ObterClientes()
        {
            return Enum.GetNames<AdministradorEnum>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}