using Microsoft.AspNetCore.Mvc;
using Servico.ViewModels;

namespace Aplicacao.Areas.Publico.Controllers
{
    public class AlterarSenhaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaViewModel alterarSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View(alterarSenha);
                }
                return View("Index", alterarSenha);
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = "Ops, não conseguimos alterar a sua senha, tente novamente!!";
                return View("Index", alterarSenha);
            }
        }
    }
}
