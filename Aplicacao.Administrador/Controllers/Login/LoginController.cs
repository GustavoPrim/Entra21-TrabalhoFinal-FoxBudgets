//using Aplicacao.Administrador.Help;
//using Microsoft.AspNetCore.Mvc;
//using Repositorio.Entidades;
//using Repositorio.Repositorios;
//using Servico.ViewModels;

//namespace Aplicacao.Administradores.Controllers
//{
//    public class LoginController : Controller
//    {
//        private readonly IAdministradorRepositorio _usuarioRepositorio;
//        private readonly ISessao _sessao;
//        public LoginController(IAdministradorRepositorio usuarioRepositorio,
//                                ISessao sessao)
//        {
//            _usuarioRepositorio = usuarioRepositorio;
//            _sessao = sessao;
//        }
//        public IActionResult Index()
//        {
//            if (_sessao.BuscarSessaoUsuario() != null)
//                return RedirectToAction("index", "Home");


//            return View();
//        }

//        public IActionResult Sair()
//        {
//            _sessao.RemoverSessaoUsuario();

//            return RedirectToAction("Index", "Login");
//        }

//        [HttpPost]
//        public IActionResult Entrar(LoginModel loginModel)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    Repositorio.Entidades.Administrador administrador = _usuarioRepositorio.BuscarPorLogin(loginModel.Login); //Verificar com Efraim questão de consulta no banco de dados

//                    if (administrador != null)
//                    {
//                        if (administrador.SenhaValida(loginModel.Senha))
//                        {
//                            _sessao.CriarSessaoUsuario(administrador);
//                            return RedirectToAction("Index", "Home");
//                        }


//                        TempData["MensagemErro"] = $"Senha do usuário é invalida, tente novamente!";
//                    }
//                    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s). Por favor, tente novamente!";
//                }
//                return View("Index");
//            }
//            catch (Exception erro)
//            {
//                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente, detalhe do erro {erro.Message}";
//                return RedirectToAction("Index");
//            }
//        }
//    }
//}
