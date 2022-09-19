using Aplicacao.Administrador.Help;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entidades;
using Repositorio.Repositorios;
using Servico.Servicos;
using Servico.ViewModels;

namespace Aplicacao.Administradores.Controllers
{
    [Area("Publico")]
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IAdministradorServico _administradorRepositorio;
        private readonly IFornecedorServico _fornecedorRepositorio;
        //private readonly IClienteService _clienteRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IAdministradorServico administradorService,
                                ISessao sessao,
                                IFornecedorServico fornecedorService)
        {
            _administradorRepositorio = administradorService;
            _sessao = sessao;
            _fornecedorRepositorio = fornecedorService;
        }
        public IActionResult Index()
        {
            //if (_sessao.BuscarSessaoUsuario() != null)
            //    return RedirectToAction("index", "Home");


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
                    //Repositorio.Entidades.Cliente cliente = _clienteRepositorio.BuscarPorLogin(loginModel.Login);

                    //if (cliente != null)
                    //{
                    //    if (cliente.SenhaValida(loginModel.Senha))
                    //    {
                    //        _sessao.CriarSessaoUsuario(cliente);
                    //        return RedirectToAction("/administrador/cliente");
                    //    }
                    //    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente!";
                    //}

                    Repositorio.Entidades.Fornecedor fornecedor = _fornecedorRepositorio.BuscarPorLogin(loginModel.Login);
                    if (fornecedor != null)
                    {
                        if (fornecedor.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(fornecedor);
                            return RedirectToAction("", "fornecedor");

                        }
                        TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente!";
                    }

                    Repositorio.Entidades.Administrador administrador = _administradorRepositorio.BuscarPorLogin(loginModel.Login);
                    if (administrador != null)
                    {
                        if (administrador.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(administrador);
                            return RedirectToAction("", "administrador");
                        }
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
    }
}
