using Aplicacao.Help;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Entidades;
using Servico.Email;
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
        private readonly IEmail _email;
        private readonly ISessao _sessao;
        public LoginController(
            IAdministradorServico administradorService,
            ISessao sessao,
            IFornecedorServico fornecedorService,
            IEmail emailService,
            IClienteService clienteRepositorio)
        {
            _administradorService = administradorService;
            _sessao = sessao;
            _fornecedorService = fornecedorService;
            _clienteService = clienteRepositorio;
            _email = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Sair")]
        [HttpGet]
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario<Administrador>();
            _sessao.RemoverSessaoUsuario<Fornecedor>();
            _sessao.RemoverSessaoUsuario<Cliente>();

            return RedirectToAction("Index", "Login");
        }

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

                    var fornecedor = _fornecedorService.BuscarPorLogin(loginModel.Login, loginModel.Senha);
                    if (fornecedor != null)
                    {
                        _sessao.CriarSessaoUsuario(fornecedor);
                        return RedirectToAction("", "Home", new { area = "fornecedor" });
                    }

                    var administrador = _administradorService.BuscarPorLogin(loginModel.Login, loginModel.Senha);
                    if (administrador != null)
                    {
                        _sessao.CriarSessaoUsuario(administrador);
                        return RedirectToAction("", "Home", new { area = "administrador" });
                    }

                    TempData["MensagemErro"] = $"Senha do usuário é invalida, tente novamente!";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente, detalhe do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var viewModel = new CadastrarUsuarioViewModel();

            return View(viewModel);
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromForm] CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
        {

            if (!ModelState.IsValid)
                return View(cadastrarUsuarioViewModel);

            if (_clienteService.VerificarEmail(cadastrarUsuarioViewModel.Email) == false)
            {
                TempData["Message"] = "Já existe uma conta com esse email, tente novamente";

                return RedirectToAction(nameof(Cadastrar));
            }

            var token = Guid.NewGuid();

            cadastrarUsuarioViewModel.Token = token;

            var user = _clienteService.Cadastrar(cadastrarUsuarioViewModel);

            var confirmationLink = Url.Action("ConfirmEmail", "Login",
                new { id = user.Id, token }, Request.Scheme);

            var email = _email.Enviar(user.Email, "Confirmação de email",
                @$"<p>Olá, {user.Nome}, como você está?
                <br>
                Confirme seu cadastro <a href='{confirmationLink}'>aqui</a>
                <br>
                Caso você não seja redirecionado, acesse pelo link abaixo:
                <br>
                {confirmationLink}<p>");

            TempData["Confirm"] = "Enviamos um email para você confirmar o seu login e se juntar ao nosso sistema!!!";
            return View(nameof(ConfirmEmail));

            _clienteService.Cadastrar(cadastrarUsuarioViewModel);

            TempData["mensagem"] = "Email enviado com sucesso!! Confirme o seu email";

            return View("Alerta/Index");

        }

        [HttpGet("confirmarEmail")]
        public IActionResult ConfirmEmail([FromQuery] int id, Guid token)
        {
            var user = _clienteService.ObterPorId(id);

            if (user == null || user.Token != token)
                TempData["mensagem"] = "Não existe nenhum usuário referido!";

            else if (user.EmailConfirmado == true)
                TempData["mensagem"] = "O usuário já possui o link confirmado!";

            else if (user.DataInspiracaoToken.TimeOfDay < DateTime.Now.TimeOfDay)
                TempData["mensagem"] = "O link foi espirado! Tente criar outra conta";

            else
            {
                TempData["mensagem"] = "O usuário foi confirmado!";
                _clienteService.AtualizarVerificarEmail(user.Id);
            }

            return View("Alerta/Index");
        }

        [Route("login-google")]
        public async Task LoginComGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> RespostaGoogle()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal.AddIdentities
                .FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value,
            });
            return Json(claims);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}