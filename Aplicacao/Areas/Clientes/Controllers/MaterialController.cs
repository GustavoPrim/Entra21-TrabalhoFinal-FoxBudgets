using Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Enuns;
using Servico.Servicos;
using Servico.ViewModels.Materiais;

namespace Aplicacao.Areas.Clientes.Controllers
{
    [Area("Clientes")]
    [Route("cliente/material")]
    [UsuarioLogado]
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet("obterTodosSelect2")]
        public IActionResult ObterTodosSelect2()
        {
            var selectViewModel = _materialService.ObterTodosSelect2();

            return Ok(selectViewModel);
        }

    }
}