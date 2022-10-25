using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace Aplicacao.Areas.Fornecedores.Controllers
{
    [Area("Fornecedores")]
    [Route("fornecedor/material")]
    public class MaterialControllerFornecedor : Controller
    {
        private readonly IMaterialService _materialService;
        public MaterialControllerFornecedor(IMaterialService materialService)
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