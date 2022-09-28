using Aplicacao.Help;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;
using Servico.ViewModels;

namespace Aplicacao.Administradores.Controllers
{
    [Area("Publico")]
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly IAdministradorServico _administradorService;
        private readonly IFornecedorServico _fornecedorService;
        private readonly IClienteService _clienteService;
        private readonly ISessao _sessao;
        public LoginController(
            IAdministradorServico administradorService,
            ISessao sessao,
            IFornecedorServico fornecedorService,
            IClienteService clienteRepositorio)
        {
            _administradorService = administradorService;
            _sessao = sessao;
            _fornecedorService = fornecedorService;
            _clienteService = clienteRepositorio;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null)
                return RedirectToAction("index", "Home");


            return View();
        }

        //public IActionResult Sair()
        //{
        //    _sessao.RemoverSessaoUsuario();

        //    return RedirectToAction("Index", "Login");
        //}

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cliente = _clienteService.BuscarPorLogin(loginModel.Login, loginModel.Senha);
                    if (cliente != null)
                    {
                        _sessao.CriarSessaoUsuario(cliente);
                        return RedirectToAction("", "Home", new { area = "Cliente" });
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente!";
                    }

                    var fornecedor = _fornecedorService.BuscarPorLogin(loginModel.Login, loginModel.Senha);
                    if (fornecedor != null)
                    {
                            _sessao.CriarSessaoUsuario(fornecedor);
                            return RedirectToAction("", "Home", new { area = "fornecedor" });
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente!";
                    }

                    var administrador = _administradorService.BuscarPorLogin(loginModel.Login, loginModel.Senha);
                    if (administrador != null)
                    {
                            _sessao.CriarSessaoUsuario(administrador);
                            return RedirectToAction("", "Home", new { area = "administrador" });
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Senha do usuário é invalida, tente novamente!";
                    }

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente, detalhe do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar()
        {
            var viewModel = new CadastrarUsuarioViewModel();

            return View(viewModel);
        }
        
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
        {
          //   _clienteService.();

            return View();
        }
    }
}